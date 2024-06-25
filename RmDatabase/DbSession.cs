using System.Data;
using Oracle.ManagedDataAccess.Client;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace RmDatabase
{
    /// <summary>
    /// Класс сессии БД.
    /// </summary>
    public class DbSession
    {
        /// <summary>
        /// Открытие сессии.
        /// </summary>
        /// <returns></returns>
        public static IDbConnection OpenSession()
        {
            return new OracleConnection(ConnectionString);
        }

        public static string Database
        {
            get
            {
                if (ConnectionString != null)
                {
                    string dataSource = ConnectionString.Split(';')
                                                    .Where(x => x.Contains("DATA SOURCE"))
                                                    .FirstOrDefault();

                    return dataSource.Split('=')[1];
                }

                return null;
            }
        }

        public static string User
        {
            get
            {
                if (ConnectionString != null)
                {
                    string user = ConnectionString.Split(';')
                                                    .Where(x => x.Contains("USER ID"))
                                                    .FirstOrDefault();

                    return user.Split('=')[1];
                }

                return null;
            }
        }

        public static string Password
        {
            get
            {
                if (ConnectionString != null)
                {
                    string password = ConnectionString.Split(';')
                                                    .Where(x => x.Contains("PASSWORD"))
                                                    .FirstOrDefault();

                    return password.Split('=')[1];
                }

                return null;
            }
        }

        private static string ConnectionString
        {
            get
            {
                // строка подключения
                if (connectionString == null)
                {
                    string json = File.ReadAllText("appsettings.json");

                    string database = JObject.Parse(json)
                        .SelectToken("Database")
                        .ToString();

                    var settings = JsonConvert.DeserializeObject<Settings>(database);

                    connectionString = settings.ConnectionString;
                }

                return connectionString;
            }
        }

        private static string connectionString;
    }
}
