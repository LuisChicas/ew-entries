using EasyWallet.Entries.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Data.Abstractions
{
    public interface IEntryRepository : IRepository<EntryData>
    {
        Task<IEnumerable<EntryData>> GetActiveEntriesByUser(int userId);
        Task<EntryData> GetActiveEntryById(int id);
    }
}
