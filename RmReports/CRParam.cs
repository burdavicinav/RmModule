namespace RmReports
{
    /// <summary>
    /// Параметр Crystal Reports.
    /// </summary>
    public class CRParam
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Список значений.
        /// </summary>
        public object[] Values { get; set; }
    }
}