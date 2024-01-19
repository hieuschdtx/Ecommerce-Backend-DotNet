using Microsoft.AspNetCore.Http;
using shopecommerce.Application.Services.NewsService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Models;
using shopecommerce.Infrastructure.Configurations;

namespace shopecommerce.Application.Queries.NewsQuery.GetAllNewsPaging
{
    public class GetAllNewsPagingQueryHandler : IQueryHandler<GetAllNewsPagingQuery, PagedList<NewsDto>>
    {
        private readonly INewsService _newsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppSetting Setting = new();

        public GetAllNewsPagingQueryHandler(INewsService newsService, IHttpContextAccessor httpContextAccessor)
        {
            _newsService = newsService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<PagedList<NewsDto>> Handle(GetAllNewsPagingQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsService.GetAllNewsListAsync();

            var data = PagedList<NewsDto>.ToPagedList(news.OrderByDescending(on => on.created_at),
                request.queryStringParameters.pageNumber,
                request.queryStringParameters.pageSize);

            var metadata = new
            {
                data.total_count,
                data.page_size,
                data.current_page,
                data.total_pages,
                data.has_next,
                data.has_previous
            };

            _httpContextAccessor.HttpContext.SetHeaderValue(Setting.headerKeyStrings.Panigation, metadata.ToJson());
            return data;
        }
    }
}
