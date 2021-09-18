using System;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Business.Abstractions
{
    public interface IEntryService
    {
        Task<int> AddEntry(int keywordId, decimal amount, DateTime date);
        Task DeleteEntry(int id);
    }
}
