using Dapper;
using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public class LabouringListRepo : ILabouringListRepo
    {
        public LabouringListRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IList<LabouringList> GetList(
            string fullName,
            List<PAgree> agreeList,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate
            )
        {
            var queryBuilder = new StringBuilder(
                @"SELECT DISTINCT ll.code, ll.surname, ll.name, ll.patronymic
                  FROM
                    omp_adm.labouring_list ll
                    JOIN omp_adm.claims_for_mats cfm ON cfm.respons_labourer = ll.code
                  WHERE 1 = 1");

            if (fullName != string.Empty)
            {
                queryBuilder.Append(" AND LOWER(ll.surname || ' ' || ll.name || ' ' || ll.patronymic) like :fullName");
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
                        .Query<LabouringList>(
                                queryBuilder.ToString(),
                                new
                                {
                                    fullName = fullName.ToLower(),
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
