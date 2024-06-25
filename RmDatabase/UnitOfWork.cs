using RmDatabase;
using System;
using System.Data;
using RmDatabase.Repo;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public IKonstrobjRepo KonstrobjRepo => new KonstrobjRepo(_dbConnection);

    public IEnterpriseRepo EnterpriseRepo => new EnterpriseRepo(_dbConnection);

    public IPAgreeRepo PAgreeRepo => new PAgreeRepo(_dbConnection);

    public ILabouringListRepo LabouringListRepo => new LabouringListRepo(_dbConnection);

    public IClassifyRepo ClassifyRepo => new ClassifyRepo(_dbConnection);

    public IGroupsInClassifyRepo GroupsInClassifyRepo => new GroupsInClassifyRepo(_dbConnection);

    public IStockObjRepo StockObjRepo => new StockObjRepo(_dbConnection);

    public IClaimsForMatsRepo ClaimsForMatsRepo => new ClaimsForMatsRepo(_dbConnection);

    public IOmpCrReportsRepo OmpCrReportsRepo => new OmpCrReportsRepo(_dbConnection);

    public UnitOfWork()
    {
        _dbConnection = DbSession.OpenSession();
    }

    public void BeginTransaction()
    {
        _transaction = _dbConnection.BeginTransaction();
    }

    private void CloseTransaction()
    {
        if (_transaction != null)
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public void Commit()
    {
        _transaction.Commit();
    }

    public void Rollback()
    {
        _transaction.Rollback();
    }

    public void Dispose()
    {
        CloseTransaction();
        CloseSession();
    }

    public void CloseSession()
    {
        if (_dbConnection != null)
        {
            _dbConnection.Close();
            _dbConnection.Dispose();
            _dbConnection = null;
        }
    }

    private IDbConnection _dbConnection;

    private IDbTransaction _transaction;
}