using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.UserQuery.GetUserById
{
    public class GetUserByIdQuery : IQuery<UserDto>
    {
        public string id { get; set; }
        public GetUserByIdQuery(string id)
        {
            this.id = id;
        }
    }
}