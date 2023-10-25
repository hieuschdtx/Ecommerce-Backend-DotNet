using AutoMapper;
using shopecommerce.Domain.Commons.Commands;
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

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.id.ToString());
            if(user == null)
            {
                return new BaseResponseDto(false, UserMessages.user_id_is_not_existed, (int)HttpStatusCode.BadRequest);
            }

            await _userRepository.UpdateAsync(_mapper.Map(request, user));
            await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Update thông tin người dùng thành công", (int)HttpStatusCode.NoContent);
        }
    }
}
