using Dapper;
using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.CategoryService;

public class CategoryService : CategoryServiceBase, ICategoryService
{
    public CategoryService( ISqlConnectionFactory factory ) : base(factory)
    {
    }

    public async Task<bool> NameExistsAsync( string name )
    {
        const string commandText = @"select exists(select 1 from categories WHERE name = @name)";
        using var conn = _factory.GetOpenConnection();
        return await conn.ExecuteScalarAsync<bool>(commandText, new { name });
    }
}