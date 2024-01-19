using Microsoft.AspNetCore.SignalR;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.DeleteProductCategory
{
    public class DeleteProductCategoryCommandHandler : ICommandHandler<DeleteProductCategoryCommand, BaseResponseDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IHubContext<DataHub> _hubContext;

        public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository, IHubContext<DataHub> hubContext)
        {
            _productCategoryRepository = productCategoryRepository;
            _hubContext = hubContext;
        }

        public async Task<BaseResponseDto> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetByIdAsync(request.id.ToString());
            if(productCategory is null)
            {
                return new BaseResponseDto(false, ProductCategoryMessages.Product_Category_id_not_existed, (int)HttpStatusCode.BadRequest);
            }

            await _productCategoryRepository.DeleteAsync(productCategory);
            await _productCategoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken: cancellationToken);
            return new BaseResponseDto(true, "Xóa thành công", (int)HttpStatusCode.OK);
        }
    }
}