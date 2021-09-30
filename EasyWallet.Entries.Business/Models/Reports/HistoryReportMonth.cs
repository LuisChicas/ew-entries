using System;

namespace EasyWallet.Entries.Business.Models.Reports
{
    public struct HistoryReportMonth
    {
        public DateTime Date { get; set; }
        public Entry[] Entries { get; set; }

        public HistoryReportMonth(DateTime date, Entry[] entries)
        {
            Date = date;
            Entries = entries;
        }
    }
}
