using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Entities
{
    public class Enterprise
    {
        public int EntCode { get; set; }

        public string Name { get; set; }

        public string TaxPayerCode { get; set; }

        public string PlCode { get; set; }
    }
}
