using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.ColorService
{
    public class ColorServiceBase
    {
        protected readonly ISqlConnectionFactory _factory;

        public ColorServiceBase(ISqlConnectionFactory factory)
        {
            _factory = factory;
        }
    }
}
