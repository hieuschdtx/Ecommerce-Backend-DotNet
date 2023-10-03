using AutoMapper;
using shopecommerce.Application.Services.ColorService;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.ColorCommand.CreateColor
{
    internal class CreateColorCommandHandler : ICommandHandler<CreateColorCommand, BaseResponseDto>
    {
        private readonly IColorRepository _colorRepository;
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public CreateColorCommandHandler(IColorRepository colorRepository, IColorService colorService, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _colorService = colorService;
            _mapper = mapper;
        }

        public async Task<BaseResponseDto> Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            if(await _colorService.CheckNameExists(request.name))
            {
                throw new BusinessRuleException("color_name_existed", ColorMessages.color_name_existed);
            }

            var color = _mapper.Map(request, new Colors());
            color.CreateTime();

            await _colorRepository.AddAsync(color);
            await _colorRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Tạo màu thành công");
        }
    }
}
