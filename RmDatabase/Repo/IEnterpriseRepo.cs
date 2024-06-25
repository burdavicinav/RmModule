using RmDatabase.Entities;
using System;
using System.Collections.Generic;

namespace RmDatabase.Repo
{
    public interface IEnterpriseRepo
    {
        IList<Enterprise> GetList(
            string name, 
            string inn, 
            string plCode, 
            DateTime? beginDate, 
            DateTime? endDate);
    }
}
