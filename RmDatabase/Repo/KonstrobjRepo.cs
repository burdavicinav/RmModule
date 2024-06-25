using Dapper;
using RmDatabase.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RmDatabase.Repo
{
    public class KonstrobjRepo : IKonstrobjRepo
    {
        public KonstrobjRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public Konstrobj GetById(int id)
        {
            return _connection.Query<Konstrobj>(
                                @"SELECT unvcode, itemcode, itemtype, sign, name
                                     FROM omp_adm.konstrobj WHERE unvcode = :id", new { id })
                                .FirstOrDefault();
        }

        public IList<Konstrobj> GetList()
        {
            return _connection.Query<Konstrobj>(
                    @"SELECT unvcode, itemcode, itemtype, sign, name
                                     FROM omp_adm.konstrobj")
                    .ToList();
        }

        public void Create(Konstrobj obj)
        {
        }

        public void Update(Konstrobj obj)
        {
        }

        public void Delete(Konstrobj obj)
        {
        }

        private IDbConnection _connection;
    }
}
