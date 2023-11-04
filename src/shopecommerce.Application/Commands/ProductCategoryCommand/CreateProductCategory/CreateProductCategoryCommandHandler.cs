using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.CreateProductCategory
{
    public class CreateProductCategoryCommandHandler : ICommandHandler<CreateProductCategoryCommand, BaseResponseDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<DataHub> _hubContext;

        public CreateProductCategoryCommandHandler(
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

        public async Task<BaseResponseDto> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            if(await _categoryRepository.GetByIdAsync(request.category_id) is null)
            {
                return new BaseResponseDto(false, CategoryMessages.category_is_not_exist, (int)HttpStatusCode.BadRequest);
            }

            if(request.promotion_id != null && await _promotionRepository.GetByIdAsync(request.promotion_id) is null)
            {
                return new BaseResponseDto(false, PromotionMessages.promotion_id_not_existed, (int)HttpStatusCode.BadRequest);
            }
            var productCategory = _mapper.Map(request, new ProductCategories());
            productCategory.CreateTime();

            await _productCategoryRepository.AddAsync(productCategory);
            await _productCategoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken: cancellationToken);
            return new BaseResponseDto(true, "Tạo thành công", (int)HttpStatusCode.Created);
        }
    }
}