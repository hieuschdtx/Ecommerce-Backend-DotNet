using System.Net;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.ProductCategoryCommand.DeleteProductCategory
{
    public class DeleteProductCategoryCommandHandler : ICommandHandler<DeleteProductCategoryCommand, BaseResponseDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<BaseResponseDto> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetByIdAsync(request.id.ToString());
            if (productCategory is null)
            {
                throw new BusinessRuleException("Product_Category_id_not_existed", ProductCategoryMessages.Product_Category_id_not_existed, HttpStatusCode.BadRequest);
            }

            await _productCategoryRepository.DeleteAsync(productCategory);
            await _productCategoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Xóa thành công");
        }
    }
}