using RmDatabase.DTO;
using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public interface IStockObjRepo
    {
        IList<StockObj> GetList(
            string sign,
            string description,
            List<ClassifyNode> groups,
            List<LabouringList> responsibleList,
            List<PAgree> agreeList,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate
            );
    }
}
