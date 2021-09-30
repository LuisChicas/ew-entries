using System;

namespace EasyWallet.Entries.Business.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int KeywordId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
