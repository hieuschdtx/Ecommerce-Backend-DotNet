using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCommand.AddImageProduct
{
    public class AddImageProductCommandHandler : ICommandHandler<AddImageProductCommand, BaseResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _environment;

        public AddImageProductCommandHandler(IProductRepository productRepository, IWebHostEnvironment environment)
        {
            _productRepository = productRepository;
            _environment = environment;
        }

        public async Task<BaseResponseDto> Handle(AddImageProductCommand request, CancellationToken cancellationToken)
        {
            if(request.thumbnails_file is not null)
            {
                var product = await _productRepository.GetByIdAsync(request.id.ToString());
                var thumbnails = new List<dynamic>();
                if(product == null)
                {
                    return new BaseResponseDto(false, ProductMessages.product_id_not_existed);
                }
                var thumbnailList = request?.thumbnails_file
                        .Where(file => file != null && file.Length > 0)
                        .Select(async file => new Image
                        {
                            fileName = await SaveFileImageExtensions.SaveFileImageAsync(file, _environment, FolderConst.Product)
                        })
                        .ToList();

                if(product?.thumnails != null)
                {
                    thumbnails = JsonConvert.DeserializeObject<List<dynamic>>(product?.thumnails);
                }

                foreach(var thumbnail in thumbnailList)
                {
                    thumbnails.Add(new { file_name = thumbnail.Result.fileName });
                }

                var jsonString = JsonConvert.SerializeObject(thumbnails);
                product.SetThumnailFileString(jsonString);
                await _productRepository.UpdateAsync(product);
                await _productRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            }
            return new BaseResponseDto(true, "Cập nhật ảnh thành công", (int)HttpStatusCode.OK);
        }
    }
}
