namespace shopecommerce.Application.Services.RoleService
{
    public interface IRoleService
    {
        Task<bool> ExistsNameAsync(string name);
        
    }
}