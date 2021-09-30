using EasyWallet.Entries.Business.Models.Reports;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Business.Abstractions
{
    public interface IReportService
    {
        Task<HistoryReport> GetHistoryReport(int userId);
        Task<MonthlyReport> GetMonthlyReport(int userId);
        Task<BalanceReport> GetBalanceReport(int userId, int incomeCategoryId);
    }
}
