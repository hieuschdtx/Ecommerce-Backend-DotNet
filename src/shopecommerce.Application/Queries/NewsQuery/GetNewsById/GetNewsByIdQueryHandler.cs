using AutoMapper;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.NewsQuery.GetNewsById
{
    public class GetNewsByIdQueryHandler : IQueryHandler<GetNewsByIdQuery, NewsDto>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        public GetNewsByIdQueryHandler(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public async Task<NewsDto> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {

            var news = await _newsRepository.GetByIdAsync(request.id);
            return _mapper.Map(news, new NewsDto());
        }
    }
}
