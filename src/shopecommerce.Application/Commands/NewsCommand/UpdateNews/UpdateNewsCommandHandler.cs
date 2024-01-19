using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.NewsCommand.UpdateNews
{
    public class UpdateNewsCommandHandler : ICommandHandler<UpdateNewsCommand, BaseResponseDto>
    {
        private readonly INewsRepository _newsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public UpdateNewsCommandHandler(
            INewsRepository newsRepository,
            IMapper mapper,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnviroment)
        {
            _webHostEnviroment = webHostEnviroment;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _newsRepository = newsRepository;
        }

        public async Task<BaseResponseDto> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            const string directoryPath = "wwwroot/images/news";
            var news = await _newsRepository.GetByIdAsync(request.id.ToString());
            var file_name = news.image;
            if(news is null)
            {
                return new BaseResponseDto(false, "Không tồn tại trong hệ thống", (int)HttpStatusCode.BadRequest);
            }

            if(request.category_id is not null && await _categoryRepository.GetByIdAsync(request.category_id) is null)
            {
                return new BaseResponseDto(false, CategoryMessages.category_is_not_exist, (int)HttpStatusCode.BadRequest);
            }

            var newsMapping = _mapper.Map(request, news);

            if(request.image_file is not null)
            {
                newsMapping.SetImageFileUrl(await SaveFileImageExtensions.SaveFileImageAsync(request.image_file, _webHostEnviroment, FolderConst.News));
                if(file_name is not null)
                {
                    File.Delete(directoryPath + file_name);
                }
            }

            newsMapping.UpdateModifiedTime();
            await _newsRepository.UpdateAsync(newsMapping);
            await _newsRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Cập nhật bài viết thành công", (int)HttpStatusCode.OK);
        }
    }
}
