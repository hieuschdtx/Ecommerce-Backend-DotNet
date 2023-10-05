using AutoMapper;
using MediatR;
using shopecommerce.Application.Services.RoleService;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.RoleCommand.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, BaseResponseDto>
    {
        private readonly IRoleService _roleService;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IRoleService roleService, IRoleRepository roleRepository, IMapper mapper)
        {
            _roleService = roleService;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponseDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (await _roleService.ExistsNameAsync(request.name))
            {
                throw new BusinessRuleException("role_name_is_existed", RoleMessages.role_name_is_existed);
            }

            var roleMapping = _mapper.Map(request, new Roles());
            roleMapping.SetNameToLower(roleMapping.name);

            await _roleRepository.AddAsync(roleMapping);
            await _roleRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Tạo quyền người dùng thành công");
        }
    }
}