using Dapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.CategoryService;

public class CategoryServiceBase
{
    protected readonly ISqlConnectionFactory _factory;

    protected CategoryServiceBase(ISqlConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
    {
        const string commandText = @"select * from categories order by display_order asc";
        using var conn = _factory.GetOpenConnection();
        return await conn.QueryAsync<CategoryDto>(commandText);
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoryFilterAsync(string searchTerm)
    {
        const string commandText = @"select * from categories where lower(name) like '%'||lower(@searchTerm)||'%'";
        using var conn = _factory.GetOpenConnection();
        return await conn.QueryAsync<CategoryDto>(commandText, new { searchTerm });
    }

}