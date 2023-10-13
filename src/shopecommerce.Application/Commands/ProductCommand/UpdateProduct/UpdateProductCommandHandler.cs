using System.Net;
using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, BaseResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IPromotionRepository _promotionRepository;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IProductCategoryRepository productCategoryRepository,
            IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.id.ToString()) ??
                                throw new BusinessRuleException("product_id_not_existed", ProductMessages.product_id_not_existed, HttpStatusCode.BadRequest);

            if (request.product_category_id != null && await _productCategoryRepository.GetByIdAsync(request.product_category_id) is null)
            {
                throw new BusinessRuleException("Product_Category_id_not_existed", ProductCategoryMessages.Product_Category_id_not_existed, HttpStatusCode.BadRequest);
            }

            if (request.promotion_id != null && await _promotionRepository.GetByIdAsync(request.promotion_id) is null)
            {
                throw new BusinessRuleException("promotion_id_not_existed", PromotionMessages.promotion_id_not_existed, HttpStatusCode.BadRequest);
            }
            var newProduct = _mapper.Map(request, product);
            newProduct.UpdateModifiedTime();

            await _productRepository.UpdateAsync(newProduct);
            await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Cập nhật thành công");
        }
    }
}