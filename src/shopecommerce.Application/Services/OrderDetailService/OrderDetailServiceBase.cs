using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.OrderDetailService
{
    public class OrderDetailServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;
        public OrderDetailServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
    }
}
