using System;

namespace EasyWallet.Entries.Api.Requests
{
    public class CreateEntryRequest
    {
        public int KeywordId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
