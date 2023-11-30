using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.NewsCommand.CreateNews
{
    public class CreateNewsCommandHandler : ICommandHandler<CreateNewsCommand, BaseResponseDto>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateNewsCommandHandler(INewsRepository newsRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<BaseResponseDto> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.category_id);
            if(category is null)
            {
                return new BaseResponseDto(false, CategoryMessages.category_is_not_exist, (int)HttpStatusCode.BadRequest);
            }

            var newNews = _mapper.Map(request, new News());

            if(request.image_file != null)
            {
                newNews.SetImageFileUrl(await SaveFileImageExtensions.SaveFileImageAsync(request.image_file, _webHostEnvironment, FolderConst.News));
            }
            newNews.CreateTime();
            await _newsRepository.AddAsync(newNews);
            await _newsRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Tạo bài viết thành công", (int)HttpStatusCode.Created);
        }
    }
}
