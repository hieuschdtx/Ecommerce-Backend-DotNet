using shopecommerce.Application.Services.NewsService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.NewsQuery.GetAllNews
{

    public class GetAllNewsQueryHandler : IQueryHandler<GetAllNewsQuery, IEnumerable<NewsDto>>
    {
        private readonly INewsService _newsService;

        public GetAllNewsQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IEnumerable<NewsDto>> Handle(GetAllNewsQuery request, CancellationToken cancellationToken)
        {
            return await _newsService.GetAllNewsListAsync();
        }
    }
}
