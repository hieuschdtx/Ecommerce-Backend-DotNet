using AutoMapper;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Exceptions;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using shopecommerce.Domain.Resources;

namespace shopecommerce.Application.Queries.RoleQuery.GetRoleById
{
    public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleByIdQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            if (!BaseGuidEx.IsGuid(request.id))
            {
                throw new BusinessRuleException("role_id_is_invalid", RoleMessages.role_id_is_invalid);
            }

            var roleData = await _roleRepository.GetByIdAsync(request.id);
            if (roleData == null)
            {
                throw new BusinessRuleException("role_id_is_not_exist", RoleMessages.role_id_is_not_exist);
            }

            var roleMapper = _mapper.Map(roleData, new RoleDto());
            return roleMapper;
        }
    }
}
