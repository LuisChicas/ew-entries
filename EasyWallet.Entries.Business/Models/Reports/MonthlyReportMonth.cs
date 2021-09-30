using System;

namespace EasyWallet.Entries.Business.Models.Reports
{
    public struct MonthlyReportMonth
    {
        public DateTime Date { get; set; }
        public MonthlyReportCategory[] Categories { get; set; }

        public MonthlyReportMonth(DateTime date, MonthlyReportCategory[] categories)
        {
            Date = date;
            Categories = categories;
        }
    }
}
