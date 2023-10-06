using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductCategoryQuery.GetProductCategoryById
{
    public class GetProductCategoryByIdQuery : IQuery<ProductCategoryDto>
    {
        public string id { get; set; }

        public GetProductCategoryByIdQuery(string id)
        {
            this.id = id;
        }
    }
}