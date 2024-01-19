using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.NewsService
{
    public class NewsService : NewsServiceBase, INewsService
    {
        public NewsService(ISqlConnectionFactory factory) : base(factory)
        {
        }
    }
}
