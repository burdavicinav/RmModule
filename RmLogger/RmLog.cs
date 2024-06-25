using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.IO;
using System.Text;

namespace RmLogger
{
    public class RmLog : ILog
    {
        public RmLog(Type type)
        {
            this.type = type;

            // строка подключения
            string json = File.ReadAllText("appsettings.json");

            string logging = JObject.Parse(json)
                .SelectToken("Logging")
                .ToString();

            var settings = JsonConvert.DeserializeObject<LogSettings>(logging);

            connectionString = settings.DBConnection;
            isDebug = settings.IsDebug;
        }

        public void Write(string log, int? user, LogLevel lvl = LogLevel.Error)
        {
            if (isDebug || lvl != LogLevel.Debug)
            {
                LogToFile(log, lvl);

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string str = @"INSERT INTO OMP_ADM.RM_EVENTLOG (OMP_USER, LVL, CLASS_NAME, DATETIME, MESSAGE)
                                    VALUES (:OMP_USER, :LVL, :CLASS_NAME, :DATETIME, :MESSAGE)";

                        using (OracleCommand cmd = new OracleCommand(str, connection))
                        {
                            cmd.Parameters.Add("OMP_USER", user);
                            cmd.Parameters.Add("LVL", lvl.ToString());
                            cmd.Parameters.Add("CLASS_NAME", type.ToString());
                            cmd.Parameters.Add("DATETIME", DateTime.Now);
                            cmd.Parameters.Add("MESSAGE", log);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        string error = string.Format("Ошибка записи лога в БД. Обратитесь к администратору! {0}:{1}",
                            e.Message, e.StackTrace);

                        LogToFile(error, LogLevel.Error);
                    }
                }
            }
        }

        public void Info(string log, int? user)
        {
            Write(log, user, LogLevel.Information);
        }

        public void Debug(string log, int? user)
        {
            Write(log, user, LogLevel.Debug);
        }

        public void Warning(string log, int? user)
        {
            Write(log, user, LogLevel.Warning);
        }

        public void Error(string log, int? user)
        {
            Write(log, user, LogLevel.Error);
        }

        public void IsDebugEnabled(bool value)
        {
            isDebug = value;
        }

        private void LogToFile(string log, LogLevel lvl)
        {
            string filePath = string.Format("{0}\\omega_rm.log", Path.GetTempPath());

            FileStream stream = File.Open(filePath, FileMode.Append);

            string message = string.Format("{0}, {1}: {2}\n", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"), lvl.ToString(), log);

            // 10 MB
            if (stream.Length + message.Length > 10485760)
            {
                stream.Dispose();

                // удалить файл
                File.Delete(filePath);

                // и создать новый
                stream = File.Open(filePath, FileMode.Append);
            }

            stream.Write(Encoding.Default.GetBytes(message), 0, message.Length);
            stream.Flush();

            stream.Dispose();
        }

        private bool isDebug;

        private Type type;

        private string connectionString;
    }
}