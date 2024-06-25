using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Entities
{
    public class Classify
    {
        public int Code { get; set; }

        public string ClCode { get; set; }

        public int ClType { get; set; }

        public string ClName { get; set; }

        public short Main { get; set; }
    }
}
