using AutoMapper;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Queries.ProductQuery.GetProductById
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _productRepository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.id);
            if(product is null)
            {
                throw new BusinessRuleException("product_id_is_invalid", ProductMessages.product_id_is_invalid, HttpStatusCode.BadRequest);
            }
            return _mapper.Map(product, new ProductDto());
        }
    }
}
