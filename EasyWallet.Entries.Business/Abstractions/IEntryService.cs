using EasyWallet.Entries.Business.Models;
using System;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Business.Abstractions
{
    public interface IEntryService
    {
        Task<int> AddEntry(int userId, int keywordId, decimal amount, DateTime date);
        Task<int> AddEntry(Entry entry);
        Task DeleteEntry(int id);
    }
}
