using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.ColorCommand.UpdateColor
{
    public class UpdateColorCommandHandler : ICommandHandler<UpdateColorCommand, BaseResponseDto>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public UpdateColorCommandHandler(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponseDto> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            var color = await _colorRepository.GetByIdAsync(request.id.ToString());

            if(color == null)
            {
                throw new BusinessRuleException("color_id_not_existed", ColorMessages.color_id_not_existed);
            }

            var colorMapping = _mapper.Map(request, color);
            colorMapping.UpdateModifiedTime();

            await _colorRepository.UpdateAsync(colorMapping);
            await _colorRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Cập nhật thành công");
        }
    }
}
