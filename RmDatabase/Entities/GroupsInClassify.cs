using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Entities
{
    public class GroupsInClassify
    {
        public int Code { get; set; }

        public int ClCode { get; set; }

        public string GrCode { get; set; }

        public string GrName { get; set; }

        public int? UpperGroup { get; set; }
    }
}
