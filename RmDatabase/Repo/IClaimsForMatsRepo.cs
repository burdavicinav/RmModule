using RmDatabase.DTO;
using RmDatabase.Entities;
using System;
using System.Collections.Generic;

namespace RmDatabase.Repo
{
    public interface IClaimsForMatsRepo
    {
        IList<ClaimsForMats> GetList(
            string num,
            DateTime? orderDate,
            List<StockObj> stockObjList,
            List<LabouringList> responsibleList,
            List<PAgree> agreeList,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate
            );
    }
}
