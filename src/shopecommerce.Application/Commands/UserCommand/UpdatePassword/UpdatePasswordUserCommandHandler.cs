using shopecommerce.Domain.Commons.Commands;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Commands.UserCommand.UpdatePassword
{
    public class UpdatePasswordUserCommandHandler : ICommandHandler<UpdatePasswordUserCommand, BaseResponseDto>
    {
        private readonly IUserRepository _userRepository;

        public UpdatePasswordUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponseDto> Handle(UpdatePasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(request.email);
            if(user == null)
            {
                return new BaseResponseDto(false, "Có lỗi xảy ra. Vui lòng thử lại sau!", (int)HttpStatusCode.BadRequest);
            }

            user.SetPassWordHash(request.password);
            user.SetModifiedDateUser();
            await _userRepository.UpdateAsync(user);
            await _userRepository.UnitOfWork.SaveEntitiesChangeAsync(cancellationToken);

            return new BaseResponseDto(true, "Cập nhật mật khẩu thành công", (int)HttpStatusCode.OK);
        }
    }
}
