using System.Data;

namespace Ash.Portfolio.Web.Framework.Database;

public interface IDatabase : IDisposable
{
    void Open();

    void Close();

    Task OpenAsync(CancellationToken cancellationToken = default);

    Task CloseAsync();

    IEnumerable<T> Query<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure);

    Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure, CancellationToken cancellationToken = default);

    T? QuerySingle<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure);

    Task<T?> QuerySingleAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure, CancellationToken cancellationToken = default);

    T ExecuteScalar<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure);

    Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null, int? commandTimeout = null, CommandType commandType = CommandType.StoredProcedure, CancellationToken cancellationToken = default);
}
