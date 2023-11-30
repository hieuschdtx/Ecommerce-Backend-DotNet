using shopecommerce.Application.Services.UserService;
using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;
using System.Net;

namespace shopecommerce.Application.Queries.UserQuery.CheckVerifyCodeUser
{
    public class CheckVerifyCodeUserQueryHandler : IQueryHandler<CheckVerifyCodeUserQuery, BaseResponseDto>
    {
        private readonly IUserService _userService;

        public CheckVerifyCodeUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<BaseResponseDto> Handle(CheckVerifyCodeUserQuery request, CancellationToken cancellationToken)
        {
            DateTimeOffset futureDateTimeOffset = DateTimeOffset.Now;
            var futureTimestamp = futureDateTimeOffset.ToUnixTimeSeconds();

            if(!await _userService.MatchVerifyCodeUserAsync(request.email, request.verify_code, futureTimestamp))
            {
                return new BaseResponseDto(false, "Mã xác minh không đúng hoặc đã hết hạn.", (int)HttpStatusCode.BadRequest);
            }

            return new BaseResponseDto(true, "Xác minh thành công", (int)HttpStatusCode.OK);
        }
    }
}
