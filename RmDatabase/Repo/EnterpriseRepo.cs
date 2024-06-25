using Dapper;
using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public class EnterpriseRepo : IEnterpriseRepo
    {
        public EnterpriseRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IList<Enterprise> GetList(
            string name, 
            string inn, 
            string plCode,
            DateTime? beginDate,
            DateTime? endDate)
        {
            var queryBuilder = new StringBuilder(
                            @"SELECT DISTINCT e.entcode, e.name, e.taxpayercode, e.plcode
                             FROM
                                omp_adm.enterprise e
                                JOIN omp_adm.claims_for_mats cfm ON cfm.cust_ent = e.entcode
                             WHERE 1 = 1");

            if (name != string.Empty)
            {
                queryBuilder.Append(" AND lower(e.name) like :name");
            }

            if (inn != string.Empty)
            {
                queryBuilder.Append(" AND e.taxpayercode like :inn");
            }

            if (plCode != String.Empty)
            {
                queryBuilder.Append(" AND e.plcode like :plcode");
            }

            if (beginDate != null)
            {
                queryBuilder.Append(" AND cfm.recDate >= :beginDate");
            }

            if (endDate != null)
            {
                queryBuilder.Append(" AND cfm.recDate <= :endDate");
            }

            return _connection
                        .Query<Enterprise>(
                                queryBuilder.ToString(), 
                                new { 
                                    name = name.ToLower(), 
                                    inn, 
                                    plCode, 
                                    beginDate, 
                                    endDate 
                                })
                        .ToList();
        }

        private IDbConnection _connection;
    }
}
