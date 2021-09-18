using EasyWallet.Data.Repositories;
using EasyWallet.Entries.Data;
using EasyWallet.Entries.Data.Abstractions;
using System.Threading.Tasks;

namespace EasyWallet.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEntryRepository Entries => _entryRepository = _entryRepository ?? new EntryRepository(_context);

        private readonly EntryContext _context;
        private EntryRepository _entryRepository;

        public UnitOfWork(EntryContext context)
        {
            _context = context;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
