using EasyWallet.Entries.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyWallet.Entries.Business.Models.Reports
{
    public class BalanceReport
    {
        public decimal CurrentBalance { get; private set; }
        public List<BalanceReportMonth> Months { get; private set; }

        public BalanceReport(EntryData[] entries, int incomeCategoryId)
        {
            if (entries != null && entries.Length > 0)
            {
                (CurrentBalance, Months) = GetBalances(entries, incomeCategoryId);
            }
        }

        private (decimal, List<BalanceReportMonth>) GetBalances(EntryData[] entries, int incomeCategoryId)
        {
            var balancesByMonth = new List<BalanceReportMonth>();
            decimal balance = 0;

            var entriesByMonth = entries
                .GroupBy(e => new DateTime(e.Date.Year, e.Date.Month, 1, 0, 0, 0))
                .OrderBy(month => month.Key);

            foreach (var month in entriesByMonth)
            {
                foreach (var entry in month)
                {
                    balance += entry.CategoryId == incomeCategoryId ? entry.Amount : -entry.Amount;
                }

                balancesByMonth.Add(new BalanceReportMonth(
                    month.Key,
                    balance
                ));
            }

            balancesByMonth = balancesByMonth.OrderByDescending(b => b.Date).ToList();
            return (balance, balancesByMonth);
        }
    }
}
