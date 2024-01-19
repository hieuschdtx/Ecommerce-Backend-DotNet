using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductQuery.GetProductById
{
    public class GetProductByIdQuery : IQuery<ProductDto>
    {
        public string id { get; set; }
        public GetProductByIdQuery(string id)
        {
            this.id = id;
        }
    }
}
