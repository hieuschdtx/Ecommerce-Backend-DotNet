using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.CategoryCommand.UpdateCategory
{
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, BaseResponseDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<DataHub> _hubContext;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IHubContext<DataHub> hubContext)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _hubContext = hubContext;
        }
        public async Task<BaseResponseDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.id.ToString());
            if(category == null)
            {
                return new BaseResponseDto(false, CategoryMessages.category_is_not_exist, (int)HttpStatusCode.BadRequest);
            }

            var result = _mapper.Map(request, category);
            result.UpdateModifiedTime();

            await _categoryRepository.UpdateAsync(result);
            await _categoryRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            await _hubContext.Clients.All.SendAsync("RELOAD_DATA_CHANGE", cancellationToken: cancellationToken);
            return new BaseResponseDto(true, "Cập nhật danh mục thành công", (int)HttpStatusCode.OK);
        }
    }
}
