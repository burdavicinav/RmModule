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
    public class StockObjRepo : IStockObjRepo
    {
        public StockObjRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IList<StockObj> GetList(
            string sign,
            string description,
            List<ClassifyNode> groups,
            List<LabouringList> responsibleList,
            List<PAgree> agreeList,
            List<Enterprise> enterprises,
            DateTime? orderBeginDate,
            DateTime? orderEndDate
            )
        {
            var queryBuilder = new StringBuilder(
                @"SELECT DISTINCT
                      s.code,
                      s.Sign,
                      s.description
                    FROM
                      (
                      SELECT
                        code,
                        CASE WHEN basetype = 0 THEN sign
                             WHEN basetype = 1 THEN nomsign
                        END AS sign,
                        description,
                        unvcode,
                        fk_materials
                      FROM
                          omp_adm.stockobj
                      ) s
                      JOIN omp_adm.claims_for_mats_cont cfmc ON cfmc.stockobj = s.code OR cfmc.repl_stockobj = s.code
                      JOIN omp_adm.claims_for_mats cfm ON cfm.code = cfmc.claim
                    WHERE 1 = 1");

            if (sign != string.Empty)
            {
                queryBuilder.Append(" AND LOWER(s.sign) like :sign");
            }

            if (description != string.Empty)
            {
                queryBuilder.Append(" AND LOWER(s.description) like :description");
            }

            if (groups.Count > 0)
            {
                queryBuilder.Append(@" AND EXISTS (
                                                SELECT 1
                                                FROM omp_adm.konstrobj_to_group ktg
                                                WHERE ktg.unvcode = s.unvcode
                                                    AND ktg.groupcode IN :groups
                                                UNION
                                                SELECT 1
                                                FROM omp_adm.material_to_group mtg
                                                WHERE mtg.materialcode = s.fk_materials
                                                    AND mtg.groupcode IN :groups
                                                )");
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
                        .Query<StockObj>(
                                queryBuilder.ToString(),
                                new
                                {
                                    sign = sign.ToLower(),
                                    description = description.ToLower(),
                                    groups = groups.Select(x => x.Code).ToArray(),
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
