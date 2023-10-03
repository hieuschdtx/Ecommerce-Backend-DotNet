namespace shopecommerce.Application.Services.ColorService
{
    public interface IColorService
    {
        Task<bool> CheckNameExists(string name);
    }
}
