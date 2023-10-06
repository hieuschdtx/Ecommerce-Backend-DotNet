using System.Net;
using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.UpdateProductCategory
{
    public class UpdateProductCategoryCommandHandler : ICommandHandler<UpdateProductCategoryCommand, BaseResponseDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public UpdateProductCategoryCommandHandler(
            IProductCategoryRepository productCategoryRepository,
            IPromotionRepository promotionRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _promotionRepository = promotionRepository;
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task<BaseResponseDto> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetByIdAsync(request.id.ToString());
            if (productCategory is null)
            {
                throw new BusinessRuleException("Product_Category_id_not_existed", ProductCategoryMessages.Product_Category_id_not_existed, HttpStatusCode.BadRequest);
            }

            if (request.promotion_id != null && _promotionRepository.GetByIdAsync(request.promotion_id) is null)
            {
                throw new BusinessRuleException("promotion_id_not_existed", PromotionMessages.promotion_id_not_existed, HttpStatusCode.BadRequest);
            }

            if (request.category_id != null && _categoryRepository.GetByIdAsync(request.category_id) is null)
            {
                throw new BusinessRuleException("category_is_not_exist", CategoryMessages.category_is_not_exist, HttpStatusCode.BadRequest);
            }

            var productCategoryMapping = _mapper.Map(request, productCategory);
            productCategoryMapping.UpdateModifiedTime();

            await _productCategoryRepository.UpdateAsync(productCategoryMapping);
            await _productCategoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Cập nhật thành công");
        }
    }
}