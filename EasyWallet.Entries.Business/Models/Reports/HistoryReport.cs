using EasyWallet.Entries.Business.Helpers;
using EasyWallet.Entries.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyWallet.Entries.Business.Models.Reports
{
    public class HistoryReport
    {
        public HistoryReportMonth[] Months { get; set; }

        public HistoryReport(IEnumerable<EntryData> entries)
        {
            Months = entries
                .GroupBy(e => new DateTime(e.Date.Year, e.Date.Month, 1))
                .Select(e => new HistoryReportMonth(e.Key, BusinessMapper.Map<Entry[]>(e.ToArray())))
                .ToArray();
        }
    }
}
