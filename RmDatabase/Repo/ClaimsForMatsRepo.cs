using Dapper;
using RmDatabase.DTO;
using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RmDatabase.Repo
{
    public class ClaimsForMatsRepo : IClaimsForMatsRepo
    {
        public ClaimsForMatsRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IList<ClaimsForMats> GetList(
            string num,
            DateTime? orderDate,
            List<StockObj> stockObjList,
            List<LabouringList> responsibleList,
            List<PAgree> agreeList,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate
            )
        {
            var queryBuilder = new StringBuilder(
                @"SELECT DISTINCT
                      cfm.code,
                      bo.name as num,
                      cfm.recdate as orderdate
                    FROM
                      omp_adm.claims_for_mats cfm
                      JOIN omp_adm.business_objects bo ON bo.doccode = cfm.code AND bo.TYPE = 263 
                      JOIN omp_adm.claims_for_mats_cont cfmc ON cfmc.claim = cfm.code");

            if (num != string.Empty)
            {
                queryBuilder.Append(" AND LOWER(bo.name) like :num");
            }

            if (orderDate != null)
            {
                queryBuilder.Append(" AND cfm.recdate = :orderDate");
            }

            if (stockObjList.Count > 0)
            {
                queryBuilder.Append(" AND (cfmc.stockobj IN :stockObjList OR cfmc.repl_stockobj IN :stockObjList)");
            }

            if (responsibleList.Count > 0)
            {
                queryBuilder.Append(" AND cfm.respons_labourer IN :responsibleList");
            }

            if (agreeList.Count > 0)
            {
                queryBuilder.Append(" AND cfm.agree IN :agreeList");
            }

            if (enterprises.Count > 0)
            {
                queryBuilder.Append(" AND cfm.cust_ent IN :enterprises");
            }

            if (orderBeginDate != null)
            {
                queryBuilder.Append(" AND cfm.recDate >= :orderBeginDate");
            }

            if (orderEndDate != null)
            {
                queryBuilder.Append(" AND cfm.recDate <= :orderEndDate");
            }

            return _connection
                        .Query<ClaimsForMats>(
                                queryBuilder.ToString(),
                                new
                                {
                                    num = num.ToLower(),
                                    orderDate,
                                    stockObjList = stockObjList.Select(x => x.Code).ToArray(),
                                    responsibleList = responsibleList.Select(x => x.Code).ToArray(),
                                    agreeList = agreeList.Select(x => x.Code).ToArray(),
                                    enterprises = enterprises.Select(x => x.EntCode).ToArray(),
                                    orderBeginDate,
                                    orderEndDate
                                })
                        .ToList();
        }

        private IDbConnection _connection;
    }
}
