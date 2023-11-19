using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.ProductCategoryQuery.GetProductCategoriesByCategoryId
{
    public class GetProductCategoriesByCategoryIdQuery : IQuery<IEnumerable<ProductCategoryDto>>
    {
        public GetProductCategoriesByCategoryIdQuery(string id)
        {
            this.id = id;
        }
        public string id { get; set; }
    }
}
