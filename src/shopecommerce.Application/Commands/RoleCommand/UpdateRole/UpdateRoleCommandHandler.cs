using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.RoleCommand.UpdateRole
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand, BaseResponseDto>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponseDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var roleData = await _roleRepository.GetByIdAsync(request.id.ToString());
            if(roleData == null)
            {
                throw new BusinessRuleException("role_id_is_not_exist", RoleMessages.role_id_is_not_exist);
            }

            roleData.SetUpdateRole(request.name, request.description);

            await _roleRepository.UpdateAsync(roleData);
            await _roleRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Cập nhật role thành công");
        }
    }
}
