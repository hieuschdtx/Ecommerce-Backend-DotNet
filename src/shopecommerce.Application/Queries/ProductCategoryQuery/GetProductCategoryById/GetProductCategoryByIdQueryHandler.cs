using System.Net;
using AutoMapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Queries.ProductCategoryQuery.GetProductCategoryById
{
    public class GetProductCategoryByIdQueryHandler : IQueryHandler<GetProductCategoryByIdQuery, ProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetProductCategoryByIdQueryHandler(
            IProductCategoryRepository productCategoryRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
        }


        public async Task<ProductCategoryDto> Handle(GetProductCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            if (!BaseGuidEx.IsGuid(request.id))
            {
                throw new BusinessRuleException("Product_Category_id_invalid", ProductCategoryMessages.Product_Category_id_invalid, HttpStatusCode.BadRequest);
            }

            var productCategory = await _productCategoryRepository.GetByIdAsync(request.id) ?? throw new BusinessRuleException("Product_Category_id_not_existed", ProductCategoryMessages.Product_Category_id_not_existed, HttpStatusCode.BadRequest);
            return _mapper.Map(productCategory, new ProductCategoryDto());
        }
    }
}