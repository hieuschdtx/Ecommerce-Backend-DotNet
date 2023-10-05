using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Commands.RoleCommand.DeleteRole
{
    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand, BaseResponseDto>
    {
        private readonly IRoleRepository _roleRepository;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponseDto> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var roleData = await _roleRepository.GetByIdAsync(request.id.ToString());
            if(roleData == null)
            {
                throw new BusinessRuleException("role_id_is_not_exist", RoleMessages.role_id_is_not_exist);
            }

            await _roleRepository.DeleteAsync(roleData);
            await _roleRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Xóa Role thành công");
        }
    }
}
