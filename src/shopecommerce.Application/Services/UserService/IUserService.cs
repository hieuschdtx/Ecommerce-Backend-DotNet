namespace shopecommerce.Application.Services.UserService;

public interface IUserService
{
    Task<bool> ExistsEmailAsync(string email);
    Task<bool> ExistsPhoneNumberAsync(string phoneNumber);
}