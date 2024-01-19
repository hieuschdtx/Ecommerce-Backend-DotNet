using Newtonsoft.Json;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCommand.DeleteProduct
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, BaseResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductPriceRepository _productPriceRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository, IProductPriceRepository productPriceRepository)
        {
            _productRepository = productRepository;
            _productPriceRepository = productPriceRepository;
        }

        public async Task<BaseResponseDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            const string directoryPath = "wwwroot/images/products";
            var product = await _productRepository.GetByIdAsync(request.id.ToString());
            if(product is null)
            {
                return new BaseResponseDto(false, ProductMessages.product_id_not_existed, (int)HttpStatusCode.BadRequest);
            }

            var productPrice = await _productPriceRepository.GetProductsPricesByProductId(product.id);

            if(productPrice is not null)
            {
                await _productPriceRepository.DeleteAsync(productPrice);
            }

            if(product.avatar is not null)
            {
                File.Delete(directoryPath + product.avatar);
            }

            if(product.thumnails is not null)
            {
                var thumbnails = JsonConvert.DeserializeObject<List<dynamic>>(product.thumnails);
                foreach(var fileName in thumbnails)
                {
                    File.Delete(directoryPath + fileName);
                }
            }

            await _productRepository.DeleteAsync(product);
            await _productPriceRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Xóa sản phẩm thành công", (int)HttpStatusCode.OK);
        }
    }
}
