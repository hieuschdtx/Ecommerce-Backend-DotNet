using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using shopecommerce.Application.Services.PromotionService;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Entities;
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
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IPromotionService _promotionService;

        public CreateProductCommandHandler(IWebHostEnvironment environment,
            IMapper mapper,
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository,
            IPromotionService promotionService,
            IProductPriceRepository productPriceRepository)
        {
            _productPriceRepository = productPriceRepository;
            _promotionService = promotionService;
            _environment = environment;
            _mapper = mapper;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<BaseResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productCatetgory = await _productCategoryRepository.GetByIdAsync(request.product_category_id);
            if(productCatetgory == null)
            {
                return new BaseResponseDto(false, ProductCategoryMessages.Product_Category_id_not_existed, (int)HttpStatusCode.BadRequest);
            }

            var newProduct = _mapper.Map(request, new Products());
            newProduct.CreateTime();
            newProduct.SetPromotionId(productCatetgory.promotion_id);

            //Kiểm tra và lưu avatar
            if(request.avatar_file != null)
            {
                newProduct.SetAvatarFileString(await SaveFileImageExtensions.SaveFileImageAsync(request.avatar_file, _environment, FolderConst.Product));
            }

            //Kiểm tra và lưu thumnail
            if(request.thumbnails_file != null && request.thumbnails_file.Any())
            {
                var thumbnailList = request?.thumbnails_file
                    .Where(file => file != null && file.Length > 0)
                    .Select(async file => new Image
                    {
                        fileName = await SaveFileImageExtensions.SaveFileImageAsync(file, _environment, FolderConst.Product)
                    })
                    .ToList();

                var thumbnailFileNames = thumbnailList.Select(x => new { file_name = x.Result.fileName }).ToList();
                var jsonString = JsonConvert.SerializeObject(thumbnailFileNames);
                newProduct.SetThumnailFileString(jsonString);
            }

            await _productRepository.AddAsync(newProduct);
            await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            //Tạo mới giá sản phẩm
            var productPrices = new ProductsPrices
            {
                id = BaseGuidEx.GetNewGuid(),
                weight = request.weight,
                price = request.price,
                product_id = newProduct.id
            };
            productPrices.SetPriceSale(await _promotionService.GetDisCount(productCatetgory.promotion_id));
            await _productPriceRepository.AddAsync(productPrices);
            await _productPriceRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Tạo thành sản phẩm thành công", (int)HttpStatusCode.Created);
        }
    }
}