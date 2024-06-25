using System.Text;

namespace RmDatabase.DTO
{
    /// <summary>
    /// Тип узла: классификатор, группа.
    /// </summary>
    public enum ClassifyNodeType { Classify, Group }

    /// <summary>
    /// Узел классификатора.
    /// </summary>
    public class ClassifyNode
    {
        /// <summary>
        /// Код.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Классификатор.
        /// </summary>
        public int ClCode { get; set; }

        /// <summary>
        /// Тип узла.
        /// </summary>
        public ClassifyNodeType Type { get; set; }

        /// <summary>
        /// Префикс.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Расширенное наименование.
        /// </summary>
        public string Description
        {
            get
            {
                var builder = new StringBuilder();

                if (Prefix != null)
                {
                    builder.Append($"[{Prefix}]");

                    if (Name != null)
                    {
                        builder.Append(' ');
                    }
                }

                if (Name != null)
                {
                    builder.Append(Name);
                }

                return builder.ToString();
            }
        }
    }
}
