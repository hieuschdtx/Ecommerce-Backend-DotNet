namespace shopecommerce.Application.Services.StatistiqueService
{
    public interface IStatistiqueService
    {
        Task<decimal> GetMonthlyRevenue(int month, int year);
        Task<List<decimal>> GetTotalAmountRevenue(int year);
        Task<List<object>> GetCountOrderFollowProCategory();
        Task<List<object>> CountOrderFullMonthOfYear(int year, int month);
    }
}
