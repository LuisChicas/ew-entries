using EasyWallet.Entries.Data;
using EasyWallet.Entries.Data.Abstractions;
using EasyWallet.Entries.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyWallet.Data.Repositories
{
    public class EntryRepository : Repository<EntryData>, IEntryRepository
    {
        private EntryContext EntryContext => Context as EntryContext;

        public EntryRepository(EntryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EntryData>> GetActiveEntriesByUser(int userId)
        {
            return await EntryContext.Entries
                .Where(e => e.UserId == userId && e.DeletedAt == null)
                .OrderByDescending(e => e.Date)
                .ToListAsync();
        }

        public Task<EntryData> GetActiveEntryById(int id)
        {
            return EntryContext.Entries
                .Where(e => e.Id == id && e.DeletedAt == null)
                .FirstOrDefaultAsync();
        }
    }
}
