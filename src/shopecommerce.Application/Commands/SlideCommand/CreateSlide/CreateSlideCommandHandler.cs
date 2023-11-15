using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Commands.SlideCommand.CreateSlide
{
    public class CreateSlideCommandHandler : ICommandHandler<CreateSlideCommand, BaseResponseDto>
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public CreateSlideCommandHandler(ISlideRepository slideRepository, IMapper mapper, IWebHostEnvironment environment)
        {
            _slideRepository = slideRepository;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<BaseResponseDto> Handle(CreateSlideCommand request, CancellationToken cancellationToken)
        {
            var slideMapping = _mapper.Map(request, new Slides());
            slideMapping.CreateTime();

            if(request.banner_image != null)
            {
                slideMapping.SetImagefileName(await SaveFileImageExtensions.SaveFileImageAsync(request.banner_image, _environment, FolderConst.Banner));
            }

            await _slideRepository.AddAsync(slideMapping);
            await _slideRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Tạo thành banner thành công", (int)HttpStatusCode.Created);
        }
    }
}
