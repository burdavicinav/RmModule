using Dapper;
using RmDatabase.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RmDatabase.Repo
{
    public class GroupsInClassifyRepo : IGroupsInClassifyRepo
    {
        public GroupsInClassifyRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IList<GroupsInClassify> GetList(int clCode, int? parent)
        {
            var queryBuilder = new StringBuilder(
                            @"SELECT gc.code, gc.clcode, gc.grcode, gc.grname, gc.upper_group
                             FROM
                                omp_adm.groups_in_classify gc
                             WHERE gc.clcode = :clCode");

            if (parent != null)
            {
                queryBuilder.Append(" AND gc.upper_group = :parent");
            }
            else
            {
                queryBuilder.Append(" AND gc.upper_group IS NULL");
            }

            queryBuilder.Append(" ORDER BY gc.grcode, gc.grname");

            return _connection
                        .Query<GroupsInClassify>(
                                queryBuilder.ToString(),
                                new
                                {
                                    clCode,
                                    parent
                                })
                        .ToList();
        }

        public IList<GroupsInClassify> GetList(int[] types, string name)
        {
            return _connection
                .Query<GroupsInClassify>(
                    @"WITH f (clcode, code, grcode, grname, parent)
                        AS
                        (
                        SELECT
                            cl.code AS clcode,
                            gic.code, 
                            gic.grcode,
                            gic.grname,
                            gic.upper_group
                        FROM
                            omp_adm.groups_in_classify gic
                            JOIN omp_adm.classify cl ON cl.code = gic.clcode
                        WHERE
                                cl.cltype IN :types
                            AND Lower(gic.grname) LIKE :name
                        UNION ALL
                        SELECT
                            f.clcode,
                            gic.code,
                            gic.grcode,
                            gic.grname,
                            gic.upper_group
                        FROM
                            f
                            JOIN omp_adm.groups_in_classify gic ON gic.code = f.parent
                        )
                        SELECT DISTINCT code, clcode, grcode, grname, parent AS uppergroup FROM f",
                    new
                    {
                        types,
                        name = name.ToLower()
                    }
                )
                .ToList();
        }

        private IDbConnection _connection;
    }
}
