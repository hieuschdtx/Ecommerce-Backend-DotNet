using shopecommerce.Application.Services.PromotionService;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCommand.UpdatePrice
{
    public class UpdateProductPriceCommandHandler : ICommandHandler<UpdateProductPriceCommand, BaseResponseDto>
    {
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IPromotionService _promotionService;

        public UpdateProductPriceCommandHandler(
            IProductPriceRepository productPriceRepository,
            IPromotionService promotionService)
        {
            _promotionService = promotionService;
            _productPriceRepository = productPriceRepository;
        }

        public async Task<BaseResponseDto> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
        {
            var productPrice = await _productPriceRepository.GetProductsPricesByProductId(request.id.ToString());
            if(productPrice is null)
            {
                throw new BusinessRuleException("product_price_id_not_existed", ProductPriceMessages.product_price_id_not_existed, HttpStatusCode.BadRequest);
            }

            var promotion = await _promotionService.GetPromotionByProductId(request.id.ToString());
            productPrice.SetPriceAndWeight(request.price, request.weight);
            productPrice.SetPriceSale(promotion.discount);

            productPrice.SetPriceAndWeight(request.price, request.weight);
            productPrice.SetPriceSale(promotion.discount);

            await _productPriceRepository.UpdateAsync(productPrice);
            await _productPriceRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Cập nhật giá thành công", (int)HttpStatusCode.OK);
        }
    }
}