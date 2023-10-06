using System.Net;
using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.CreateProductCategory
{
    public class CreateProductCategoryCommandHandler : ICommandHandler<CreateProductCategoryCommand, BaseResponseDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public CreateProductCategoryCommandHandler(
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

        public async Task<BaseResponseDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _categoryRepository.GetByIdAsync(request.category_id) is null)
            {
                throw new BusinessRuleException("category_is_not_exist", CategoryMessages.category_is_not_exist, HttpStatusCode.BadRequest);
            }

            if (request.promotion_id != null && await _promotionRepository.GetByIdAsync(request.promotion_id) is null)
            {
                throw new BusinessRuleException("promotion_id_not_existed", PromotionMessages.promotion_id_not_existed, HttpStatusCode.BadRequest);
            }
            var productCategory = _mapper.Map(request, new ProductCategories());
            productCategory.CreateTime();

            await _productCategoryRepository.AddAsync(productCategory);
            await _productCategoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Tạo thành công");
        }
    }
}