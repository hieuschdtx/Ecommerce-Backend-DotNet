using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using shopecommerce.Application.Services.UserService;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Consts;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Extensions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.UserCommand.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, BaseResponseDto>
    {
        private readonly IUserService _userService;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserService userService, IRoleRepository roleRepository,
            IMapper mapper, IUserRepository userRepository,
            IWebHostEnvironment environment)
        {
            _environment = environment;
            _userService = userService;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<BaseResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(await _userService.ExistsEmailAsync(request.email))
            {
                return new BaseResponseDto(false, UserMessages.user_email_existed, (int)HttpStatusCode.BadRequest);
            }

            if(await _userService.ExistsPhoneNumberAsync(request.phone_number))
            {
                return new BaseResponseDto(false, UserMessages.user_phone_number_is_existed, (int)HttpStatusCode.BadRequest);
            }

            if(await _roleRepository.GetByIdAsync(request.role_id) is null)
            {
                return new BaseResponseDto(false, RoleMessages.role_name_is_existed, (int)HttpStatusCode.BadRequest);
            }

            var userMapping = _mapper.Map<Users>(request);

            if(request.avatar_file is not null)
            {
                userMapping.avatar = await SaveFileImageExtensions.SaveFileImageAsync(request.avatar_file, _environment, FolderConst.Avatar);
            }
            userMapping.dob = BaseEntites.ParsedDob(request.day_of_birth);
            userMapping.SetRoleUser(request.role_id);
            userMapping.SetPassWordHash(userMapping.password);
            userMapping.SetCreatedatUser();

            await _userRepository.AddAsync(userMapping);
            await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Tạo người dùng thành công", (int)HttpStatusCode.Created);
        }
    }
}
