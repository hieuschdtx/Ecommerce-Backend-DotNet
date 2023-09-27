using System.Data;

namespace shopecommerce.Domain.Commons;

public interface ISqlConnectionFactory
{
    IDbConnection GetOpenConnection();
}