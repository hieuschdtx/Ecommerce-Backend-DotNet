using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ColorQuery.GetColorById
{
    public class GetColorByIdQuery : IQuery<ColorDto>
    {
        public string id { get; set; }
        public GetColorByIdQuery(string id)
        {
            this.id = id;
        }
    }
}
