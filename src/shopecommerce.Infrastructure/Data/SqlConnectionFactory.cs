using Microsoft.Extensions.Configuration;
using Npgsql;
using shopecommerce.Domain.Commons;
using System.Data;

namespace shopecommerce.Infrastructure.Data;

public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
{
    private readonly IConfiguration _configuration;
    private IDbConnection _connection;
    public SqlConnectionFactory(IConfiguration configuration, IDbConnection dbConnection)
    {
        _configuration = configuration;
        _connection = dbConnection;
    }

    public void Dispose()
    {
        if(_connection is { State: ConnectionState.Open })
            _connection.Dispose();
    }

    public IDbConnection GetOpenConnection()
    {
        if(_connection.State == ConnectionState.Open)
            return _connection;
        _connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        _connection.Open();

        return _connection;
    }
}