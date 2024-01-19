using shopecommerce.Domain.Commons;

namespace shopecommerce.Application.Services.StatistiqueService
{
    public class StatistiqueService : StatistiqueServiceBase, IStatistiqueService
    {
        public StatistiqueService(ISqlConnectionFactory factory) : base(factory)
        {
        }
    }
}
