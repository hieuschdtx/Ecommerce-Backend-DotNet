using shopecommerce.Application.Services.PromotionService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCommand.CreatePrice;

public class CreatePriceCommandHandler : ICommandHandler<CreatePriceCommand, BaseResponseDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductPriceRepository _productPriceRepository;
    private readonly IPromotionService _promotionService;

    public CreatePriceCommandHandler(
        IProductRepository productRepository,
        IPromotionService promotionService,
            IProductPriceRepository productPriceRepository)
    {
        _productPriceRepository = productPriceRepository;
        _promotionService = promotionService;
        _productRepository = productRepository;
    }

    public async Task<BaseResponseDto> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        if(await _productRepository.GetByIdAsync(request.id.ToString()) is null)
        {
            return new BaseResponseDto(false, ProductMessages.product_id_not_existed, (int)HttpStatusCode.BadRequest);
        }
        var promotion = await _promotionService.GetPromotionByProductId(request.id.ToString());

        foreach(var price in request.prices)
        {
            ProductsPrices productsPrices = new()
            {
                id = BaseGuidEx.GetNewGuid().ToString(),
                price = price.price,
                weight = price.weight,
                product_id = request.id.ToString()
            };
            productsPrices.SetPriceSale(promotion.discount);
            await _productPriceRepository.AddAsync(productsPrices);
            await _productPriceRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
        }
        return new BaseResponseDto(true, "Tạo thành công", (int)HttpStatusCode.Created);
    }
}