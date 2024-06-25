using System.Text;

namespace RmDatabase.Entities
{
    public class LabouringList
    {
        public int Code { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string FullName 
        {
            get
            {
                var nameBuilder = new StringBuilder();

                if (SurName != null)
                {
                    nameBuilder.Append(SurName);

                    if (Name != null)
                    {
                        nameBuilder.Append(' ');
                    }
                }

                if (Name != null)
                {
                    nameBuilder.Append(Name);

                    if (Patronymic != null)
                    {
                        nameBuilder.Append(' ');
                    }
                }

                if (Patronymic != null)
                {
                    nameBuilder.Append(Patronymic);
                }

                return nameBuilder.ToString();
            }
        }
    }
}
