using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using shopecommerce.Application.Services.PromotionService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCommand.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, BaseResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IPromotionService _promotionService;

        public CreateProductCommandHandler(IWebHostEnvironment environment,
            IMapper mapper,
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository,
            IPromotionRepository promotionRepository,
            IPromotionService promotionService,
            IProductPriceRepository productPriceRepository)
        {
            _productPriceRepository = productPriceRepository;
            _promotionService = promotionService;
            _environment = environment;
            _mapper = mapper;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _promotionRepository = promotionRepository;
        }

        public async Task<BaseResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCatetgory = await _productCategoryRepository.GetByIdAsync(request.product_category_id) ??
                throw new BusinessRuleException("Product_Category_id_not_existed",
                ProductCategoryMessages.Product_Category_id_not_existed,
                HttpStatusCode.BadRequest);

            if (!string.IsNullOrEmpty(request.promotion_id) && await _promotionRepository.GetByIdAsync(request.promotion_id) is null)
            {
                throw new BusinessRuleException("promotion_id_not_existed", PromotionMessages.promotion_id_not_existed,
                HttpStatusCode.BadRequest);
            }
            var newProduct = _mapper.Map(request, new Products());
            newProduct.CreateTime();

            //Kiểm tra và lưu avatar
            if (request.thumbnails_file != null)
            {
                newProduct.SetAvatarFileString(await SaveFileImageExtensions.SaveFileImageAsync(request?.avatar_file, _environment, FolderConst.Product));
            }

            //Kiểm tra và lưu thumnail
            if (request.thumbnails_file != null && request.thumbnails_file.Count > 0)
            {
                var thumbnailList = request?.thumbnails_file
                    .Where(file => file != null && file.Length > 0)
                    .Select(async file => new Image
                    {
                        fileName = await SaveFileImageExtensions.SaveFileImageAsync(file, _environment, FolderConst.Product)
                    })
                    .ToList();
                newProduct.SetThumnailFileString(JsonConvert.SerializeObject(thumbnailList));
            }

            await _productRepository.AddAsync(newProduct);
            await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            //Tạo mới giá sản phẩm
            var productPrices = new List<ProductsPrices>();
            foreach (var price in request.prices)
            {
                if (price.price >= 0 && price.weight >= 0)
                {
                    productPrices.Add(new ProductsPrices
                    {
                        id = BaseGuidEx.GetNewGuid(),
                        weight = price.weight,
                        price = price.price,
                        product_id = newProduct.id,
                        price_sale = await _promotionService.GetDisCount(productCatetgory.promotion_id)
                    });
                }
            }
            var addTasks = productPrices.Select(productPrice => _productPriceRepository.AddAsync(productPrice));
            await Task.WhenAll(addTasks);
            await _productPriceRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Tạo thành công");
        }
    }
}