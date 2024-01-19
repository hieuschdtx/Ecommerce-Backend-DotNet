using AutoMapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Queries.CategoryQuery.GetCategoryById
{
    internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            if(!BaseGuidEx.IsGuid(request.category_id))
                throw new BusinessRuleException("category_id_is_invalid", CategoryMessages.category_id_is_invalid);
            var result = await _categoryRepository.GetByIdAsync(request.category_id);
            return _mapper.Map<CategoryDto>(result);
        }
    }
}
