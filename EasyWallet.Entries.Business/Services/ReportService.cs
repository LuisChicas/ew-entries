using EasyWallet.Entries.Business.Abstractions;
using EasyWallet.Entries.Business.Models.Reports;
using EasyWallet.Entries.Data.Abstractions;
using EasyWallet.Entries.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Business.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HistoryReport> GetHistoryReport(int userId)
        {
            IEnumerable<EntryData> entries = await _unitOfWork.Entries.GetActiveEntriesByUser(userId);
            return new HistoryReport(entries);
        }
        public async Task<MonthlyReport> GetMonthlyReport(int userId)
        {
            IEnumerable<EntryData> entries = await _unitOfWork.Entries.GetActiveEntriesByUser(userId);
            return new MonthlyReport(entries);
        }

        public async Task<BalanceReport> GetBalanceReport(int userId, int incomeCategoryId)
        {
            IEnumerable<EntryData> entries = await _unitOfWork.Entries.GetActiveEntriesByUser(userId);
            return new BalanceReport(entries.ToArray(), incomeCategoryId);
        }
    }
}
