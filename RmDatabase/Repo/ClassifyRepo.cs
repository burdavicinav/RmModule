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
    public class ClassifyRepo : IClassifyRepo
    {
        public ClassifyRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IList<Classify> GetByTypes(int[] types)
        {
            return _connection
                        .Query<Classify>(
                                @"SELECT code, clcode, cltype, clname, main
                                  FROM omp_adm.classify WHERE cltype IN :types",
                                new { types })
                        .ToList();
        }

        public Classify GetByCode(int code)
        {
            return _connection
                        .Query<Classify>(
                                @"SELECT code, clcode, cltype, clname, main
                                  FROM omp_adm.classify WHERE code = :code",
                                new { code })
                        .SingleOrDefault();
        }

        private IDbConnection _connection;
    }
}
