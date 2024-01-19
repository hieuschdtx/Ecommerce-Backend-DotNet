using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Commands.NewsCommand.DeleteNews
{
    public class DeleteNewsCommandHandler : ICommandHandler<DeleteNewsCommand, BaseResponseDto>
    {
        private readonly INewsRepository _newsRepository;
        public DeleteNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public async Task<BaseResponseDto> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            const string directoryPath = "wwwroot/images/news";
            var news = await _newsRepository.GetByIdAsync(request.id.ToString());
            if(news is null)
            {
                return new BaseResponseDto(false, "Không tồn tại bài viết trong hệ thống", (int)HttpStatusCode.BadRequest);
            }

            if(news.image is not null)
            {
                File.Delete(directoryPath + news.image);
            }

            await _newsRepository.DeleteAsync(news);
            await _newsRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);
            return new BaseResponseDto(true, "Xóa bài viết thành công", (int)HttpStatusCode.OK);
        }
    }
}
