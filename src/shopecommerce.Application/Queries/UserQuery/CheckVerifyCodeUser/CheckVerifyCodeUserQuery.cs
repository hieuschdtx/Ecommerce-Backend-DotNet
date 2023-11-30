using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.UserQuery.CheckVerifyCodeUser
{
    public class CheckVerifyCodeUserQuery : IQuery<BaseResponseDto>
    {
        public string email { get; set; }
        public string verify_code { get; set; }
    }
}
