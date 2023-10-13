using System.Net;
using shopecommerce.Application.Services.PromotionService;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

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
            foreach (var price in request.product_price)
            {
                var productPrice = await _productPriceRepository.GetProductsPricesByProductId(price.id, request.id.ToString());
                if (productPrice is null)
                {
                    throw new BusinessRuleException("product_price_id_not_existed", ProductPriceMessages.product_price_id_not_existed, HttpStatusCode.BadRequest);
                }

                var promotion = await _promotionService.GetPromotionByProductId(request.id.ToString());
                productPrice.SetPriceAndWeight(price.price, price.weight);
                productPrice.SetPriceSale(promotion.discount);

                await _productPriceRepository.UpdateAsync(productPrice);
                await _productPriceRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            }
            return new BaseResponseDto(true, "Cập nhật giá thành công");
        }
    }
}