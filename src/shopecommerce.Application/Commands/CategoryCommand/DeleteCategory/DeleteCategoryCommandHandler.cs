using Microsoft.AspNetCore.SignalR;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.CategoryCommand.DeleteCategory
{
    public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, BaseResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHubContext<DataHub> _hubContext;


        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IHubContext<DataHub> hubContext)
        {
            _categoryRepository = categoryRepository;
            _hubContext = hubContext;
        }

        public async Task<BaseResponseDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if(!BaseGuidEx.IsGuid(request.category_id))
                return new BaseResponseDto(false, CategoryMessages.category_id_is_invalid, (int)HttpStatusCode.BadRequest);

            var category = await _categoryRepository.GetByIdAsync(request.category_id);
            if(category == null)
            {
                return new BaseResponseDto(false, CategoryMessages.category_is_not_exist, (int)HttpStatusCode.BadRequest);
            }

            await _categoryRepository.DeleteAsync(category);
            await _categoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken: cancellationToken);

            return new BaseResponseDto(true, "Xóa danh mục thành công", (int)HttpStatusCode.OK);
        }
    }
}
