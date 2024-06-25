using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public interface ILabouringListRepo
    {
        IList<LabouringList> GetList(
            string fullName,
            List<PAgree> agreeList,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate
            );
    }
}
