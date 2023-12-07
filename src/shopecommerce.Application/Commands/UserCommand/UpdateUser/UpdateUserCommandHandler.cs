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

namespace shopecommerce.Application.Commands.UserCommand.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, BaseResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IWebHostEnvironment environment)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<BaseResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id.ToString());
            if(user == null)
            {
                return new BaseResponseDto(false, UserMessages.user_id_is_not_existed, (int)HttpStatusCode.BadRequest);
            }
            var updateUser = _mapper.Map(request, user);

            if(request.avatar_file != null)
            {
                updateUser.SetAvatarFileString(await SaveFileImageExtensions.SaveFileImageAsync(request.avatar_file, _environment, FolderConst.Avatar));
            }
            user.dob = BaseEntites.ParsedDob(request.day_of_birth);

            await _userRepository.UpdateAsync(updateUser);
            await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Cập nhật thông tin thành công", (int)HttpStatusCode.OK);
        }
    }
}
