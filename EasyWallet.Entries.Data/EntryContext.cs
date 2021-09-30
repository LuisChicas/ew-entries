using EasyWallet.Entries.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyWallet.Entries.Data
{
    public class EntryContext : DbContext
    {
        public DbSet<EntryData> Entries { get; set; }

        public EntryContext(DbContextOptions<EntryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EntryData>(e =>
            {
                e.Property(e => e.UserId).IsRequired();
                e.Property(e => e.CategoryId).IsRequired();
                e.Property(e => e.KeywordId).IsRequired();
                e.Property(e => e.Amount)
                    .HasColumnType("decimal(6, 2)")
                    .IsRequired();
                e.Property(e => e.CreatedAt).IsRequired();
            });
        }
    }
}
