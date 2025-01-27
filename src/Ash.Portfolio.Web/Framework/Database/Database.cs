using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Ash.Portfolio.Web.Framework.Database;

public class Database : IDatabase
{
    private bool isDisposed;
    private readonly SqlConnection _connection;

    public Database(string connectionString) : this(new SqlConnection(connectionString))
    {

    }

    public Database(SqlConnection connection)
    {
        _connection = connection;
    }

    public void Open()
    {
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Close();
            _connection.Open();
        }
    }

    public void Close()
    {
        _connection?.Close();
    }

    public async Task OpenAsync(CancellationToken cancellationToken = default)
    {
        if (_connection.State != ConnectionState.Open)
        {
            await _connection.CloseAsync();
            await _connection.OpenAsync(cancellationToken);
        }
    }

    public Task CloseAsync()
    {
        return _connection?.CloseAsync()!;
    }

    public IEnumerable<T> Query<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure)
    {
        return _connection.Query<T>(sql, param, commandType: commandType, commandTimeout: commandTimeout);
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure, CancellationToken cancellationToken = default)
    {
        return await _connection.QueryAsync<T>(CreateCommandDefinition(sql, param, commandTimeout, commandType, cancellationToken));
    }

    public T? QuerySingle<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure)
    {
        return _connection.QuerySingleOrDefault<T>(sql, param, commandType: commandType, commandTimeout: commandTimeout);
    }

    public async Task<T?> QuerySingleAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure, CancellationToken cancellationToken = default)
    {
        return await _connection.QuerySingleOrDefaultAsync<T>(CreateCommandDefinition(sql, param, commandTimeout, commandType, cancellationToken, CommandFlags.None));
    }

    public T ExecuteScalar<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure)
    {
        return _connection.ExecuteScalar<T>(sql, param, commandType: commandType, commandTimeout: commandTimeout)!;
    }

    public async Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure, CancellationToken cancellationToken = default)
    {
        return await _connection.ExecuteScalarAsync<T>(CreateCommandDefinition(sql, param, commandTimeout, commandType, cancellationToken));
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (isDisposed)
            return;

        if (disposing)
        {
            if (_connection?.State != ConnectionState.Closed)
            {
                _connection?.Close();
                _connection?.Dispose();
            }
        }

        isDisposed = true;
    }

    private CommandDefinition CreateCommandDefinition(string sql, object? param, int? commandTimeout, CommandType commandType, CancellationToken cancellationToken, CommandFlags flags = CommandFlags.Buffered)
    {
        return new CommandDefinition(sql, parameters: param, commandTimeout: commandTimeout, commandType: commandType, cancellationToken: cancellationToken, flags: flags);
    }
}
