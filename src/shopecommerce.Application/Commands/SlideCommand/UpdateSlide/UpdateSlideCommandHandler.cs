using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Commands.SlideCommand.UpdateSlide
{
    public class UpdateSlideCommandHandler : ICommandHandler<UpdateSlideCommand, BaseResponseDto>
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IMapper _mapper;
        public UpdateSlideCommandHandler(ISlideRepository slideRepository, IMapper mapper)
        {
            _slideRepository = slideRepository;
            _mapper = mapper;
        }

        public Task<BaseResponseDto> Handle(UpdateSlideCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();
        }
    }
}
