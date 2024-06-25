using System;

namespace RmDatabase.DTO
{
    /// <summary>
    /// Заявка на ресурсы.
    /// </summary>
    public class ClaimsForMats
    {
        /// <summary>
        /// Код.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        public string Num { get; set; }

        /// <summary>
        /// Дата.
        /// </summary>
        public DateTime OrderDate { get; set; }
    }
}
