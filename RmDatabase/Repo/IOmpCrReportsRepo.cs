using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public interface IOmpCrReportsRepo
    {
        OmpCrReports GetByCode(int code);

        OmpCrReports GetByName(string name);
    }
}
