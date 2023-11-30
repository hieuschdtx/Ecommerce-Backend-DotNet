using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Services.NewsService
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDto>> GetAllNewsListAsync();
    }
}
