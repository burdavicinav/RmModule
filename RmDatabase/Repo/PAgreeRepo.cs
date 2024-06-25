using Dapper;
using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RmDatabase.Repo
{
    public class PAgreeRepo : IPAgreeRepo
    {
        public PAgreeRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IList<PAgree> GetList(
            string agreeNum,
            DateTime? agreeDate,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate)
        {
            var queryBuilder = new StringBuilder(
                            @"SELECT DISTINCT pa.code, pa.num AS agreeNum, pa.agree_date AS agreeDate
                             FROM
                                omp_adm.p_agree pa
                                JOIN omp_adm.claims_for_mats cfm ON cfm.agree = pa.code
                             WHERE 1 = 1");

            if (agreeNum != string.Empty)
            {
                queryBuilder.Append(" AND LOWER(pa.num) like :agreeNum");
            }

            if (agreeDate != null)
            {
                queryBuilder.Append(" AND pa.agree_date = :agreeDate");
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
                        .Query<PAgree>(
                                queryBuilder.ToString(),
                                new { 
                                    agreeNum = agreeNum.ToLower(), 
                                    agreeDate,
                                    enterprises = enterprises.Select(x => x.EntCode).ToArray(),
                                    orderBeginDate,
                                    orderEndDate 
                                })
                        .ToList();
        }

        private readonly IDbConnection _connection;
    }
}
