using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCommand.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, BaseResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponseDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.id.ToString());
            var productCategory = new ProductCategories();

            if(product is null)
            {
                return new BaseResponseDto(false, ProductMessages.product_id_not_existed, (int)HttpStatusCode.BadRequest);
            }

            if(request.product_category_id != null)
            {
                productCategory = await _productCategoryRepository.GetByIdAsync(request.product_category_id);
                if(productCategory is null)
                {
                    return new BaseResponseDto(false, ProductCategoryMessages.Product_Category_id_not_existed, (int)HttpStatusCode.BadRequest);
                }
            }

            var newProduct = _mapper.Map(request, product);
            newProduct.UpdateModifiedTime();
            newProduct.SetPromotionId(productCategory.promotion_id);

            await _productRepository.UpdateAsync(newProduct);
            await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Cập nhật sản phẩm thành công", (int)HttpStatusCode.OK);
        }
    }
}