using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.UpdateProductCategory
{
    public class UpdateProductCategoryCommandHandler : ICommandHandler<UpdateProductCategoryCommand, BaseResponseDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<DataHub> _hubContext;

        public UpdateProductCategoryCommandHandler(
            IProductCategoryRepository productCategoryRepository,
            IPromotionRepository promotionRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper, IHubContext<DataHub> hubContext)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _promotionRepository = promotionRepository;
            _productCategoryRepository = productCategoryRepository;
            _hubContext = hubContext;
        }
        public async Task<BaseResponseDto> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetByIdAsync(request.id.ToString());
            if(productCategory is null)
            {
                return new BaseResponseDto(false, ProductCategoryMessages.Product_Category_id_not_existed, (int)HttpStatusCode.BadRequest);
            }

            if(request.promotion_id != null && _promotionRepository.GetByIdAsync(request.promotion_id) is null)
            {
                return new BaseResponseDto(false, PromotionMessages.promotion_id_not_existed, (int)HttpStatusCode.BadRequest);
            }

            if(request.category_id != null && _categoryRepository.GetByIdAsync(request.category_id) is null)
            {
                return new BaseResponseDto(false, CategoryMessages.category_is_not_exist, (int)HttpStatusCode.BadRequest);
            }

            var productCategoryMapping = _mapper.Map(request, productCategory);
            productCategoryMapping.UpdateModifiedTime();

            await _productCategoryRepository.UpdateAsync(productCategoryMapping);
            await _productCategoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken: cancellationToken);
            return new BaseResponseDto(true, "Cập nhật thành công", (int)HttpStatusCode.OK);
        }
    }
}