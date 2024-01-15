using System.Data.SqlClient;

namespace MedicalCommunicationSystem.DataAccessLayer;

public class UnitOfWork : IDisposable
{
    private readonly SqlConnection _connection;
    private readonly SqlTransaction _transaction;
    private bool _disposed;

    public UnitOfWork(string connectionString)
    {
        _connection = new SqlConnection(connectionString);
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }

    public SqlConnection Connection => _connection;

    public SqlTransaction Transaction => _transaction;

    public void Commit()
    {
        _transaction.Commit();
        _connection.Close();
    }

    public void Rollback()
    {
        _transaction.Rollback();
        _connection.Close();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _connection.Dispose();
        }
        _disposed = true;
    }
}
