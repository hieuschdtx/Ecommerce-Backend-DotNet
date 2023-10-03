using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.ColorCommand.DeleteColor
{
    public class DeleteColorCommandHandler : ICommandHandler<DeleteColorCommand, BaseResponseDto>
    {
        private readonly IColorRepository _colorRepository;

        public DeleteColorCommandHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<BaseResponseDto> Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            var color = await _colorRepository.GetByIdAsync(request.id.ToString());
            if(color is null)
            {
                throw new BusinessRuleException("color_id_not_existed", ColorMessages.color_id_not_existed);
            }

            await _colorRepository.DeleteAsync(color);
            await _colorRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Xóa thành công");
        }
    }
}
