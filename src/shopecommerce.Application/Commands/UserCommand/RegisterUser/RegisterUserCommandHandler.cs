using AutoMapper;
using shopecommerce.Application.Services.UserService;
using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;
using System.Net;

namespace shopecommerce.Application.Commands.UserCommand.RegisterUser;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, BaseResponseDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IUserService userService, IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository)
    {
        _userService = userService;
        _userRepository = userRepository;
        _mapper = mapper;
        _roleRepository = roleRepository;
    }

    public async Task<BaseResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if(await _userService.ExistsEmailAsync(request.email))
        {
            return new BaseResponseDto(false, UserMessages.user_email_existed, (int)HttpStatusCode.BadRequest);
        }

        if(await _userService.ExistsPhoneNumberAsync(request.phone_number))
        {
            return new BaseResponseDto(false, UserMessages.user_phone_number_is_existed, (int)HttpStatusCode.BadRequest);
        }

        var dataRole = await _roleRepository.GetRoleByNameAsync(request.name_role);

        if(dataRole == null)
        {
            return new BaseResponseDto(false, RoleMessages.role_name_is_invalid, (int)HttpStatusCode.BadRequest);
        }

        var userMapping = _mapper.Map<Users>(request);
        userMapping.SetRoleUser(dataRole.id);
        userMapping.SetPassWordHash(userMapping.password);
        userMapping.SetCreatedatUser();

        await _userRepository.AddAsync(userMapping);
        await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

        return new BaseResponseDto(true, "Đăng ký người dùng thành công", (int)HttpStatusCode.Created);
    }
}