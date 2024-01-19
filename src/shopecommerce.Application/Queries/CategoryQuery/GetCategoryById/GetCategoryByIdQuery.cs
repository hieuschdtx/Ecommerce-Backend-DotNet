using shopecommerce.Domain.Commons.Queries;
using shopecommerce.Domain.Models;

namespace shopecommerce.Application.Queries.CategoryQuery.GetCategoryById
{
    public class GetCategoryByIdQuery : IQuery<CategoryDto>
    {
        public string category_id { get; set; }
    }
}
