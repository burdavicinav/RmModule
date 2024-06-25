using Dapper;
using RmDatabase.DTO;
using RmDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmDatabase.Repo
{
    public class OmpCrReportsRepo : IOmpCrReportsRepo
    {
        public OmpCrReportsRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public OmpCrReports GetByCode(int code)
        {
            return _connection
                        .Query<OmpCrReports>(
                                @"SELECT
                                    code,
                                    name,
                                    data
                                FROM
                                    omp_adm.omp_cr_reports
                                WHERE code = :code",
                                new
                                {
                                    code
                                })
                        .SingleOrDefault();
        }

        public OmpCrReports GetByName(string name)
        {
            return _connection
                        .Query<OmpCrReports>(
                                @"SELECT
                                    code,
                                    name,
                                    data
                                FROM
                                    omp_adm.omp_cr_reports
                                WHERE name = :name",
                                new
                                {
                                    name
                                })
                        .SingleOrDefault();
        }

        private IDbConnection _connection;
    }
}
