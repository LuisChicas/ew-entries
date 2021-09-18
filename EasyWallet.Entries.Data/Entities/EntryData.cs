using System;

namespace EasyWallet.Entries.Data.Entities
{
    public class EntryData : Entity
    {
        public int UserId { get; set; }
        public int KeywordId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
