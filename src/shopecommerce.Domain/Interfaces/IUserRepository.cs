using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;

namespace shopecommerce.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<Users>
{
    Task<Users> GetUserByPhoneNumber(string phoneNumber);
    Task<Users> GetUserByEmail(string email);
}