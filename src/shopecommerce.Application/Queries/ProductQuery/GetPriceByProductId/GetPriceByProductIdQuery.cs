using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetPriceByProductId
{
    public class GetPriceByProductIdQuery : IQuery<ProductPriceDto>
    {
        public string id { get; set; }
        public GetPriceByProductIdQuery(string id)
        {
            this.id = id;
        }
    }
}
