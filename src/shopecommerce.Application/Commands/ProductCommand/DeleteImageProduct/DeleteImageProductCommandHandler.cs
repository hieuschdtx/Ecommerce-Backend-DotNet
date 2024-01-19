using Newtonsoft.Json;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCommand.DeleteImageProduct
{
    public class DeleteImageProductCommandHandler : ICommandHandler<DeleteImageProductCommand, BaseResponseDto>
    {
        private readonly IProductRepository _productRepository;

        public DeleteImageProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<BaseResponseDto> Handle(DeleteImageProductCommand request, CancellationToken cancellationToken)
        {
            const string directoryPath = "wwwroot/images/products";

            var product = await _productRepository.GetByIdAsync(request.id.ToString());
            if(product == null)
            {
                return new BaseResponseDto(false, ProductMessages.product_id_not_existed);
            }

            var thumbnails = JsonConvert.DeserializeObject<List<dynamic>>(product.thumnails);
            foreach(var fileName in request.files_name)
            {
                if(string.IsNullOrWhiteSpace(fileName))
                    continue;

                var matchingThumbnail = thumbnails.FirstOrDefault(t => t.file_name == fileName);
                if(matchingThumbnail != null)
                {
                    thumbnails.Remove(matchingThumbnail);
                    File.Delete(directoryPath + fileName);
                }
            }

            var jsonString = JsonConvert.SerializeObject(thumbnails);
            product.SetThumnailFileString(jsonString);

            await _productRepository.UpdateAsync(product);
            await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Cập nhật thành công", (int)HttpStatusCode.OK);
        }
    }
}
