namespace RmDatabase.DTO
{
    /// <summary>
    /// ТМЦ.
    /// </summary>
    public class StockObj
    {
        /// <summary>
        /// Код.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Обозначение.
        /// </summary>
        public string Sign { get; set; }

        /// <summary>
        /// Расширенное наименование.
        /// </summary>
        public string Description { get; set; }
    }
}
