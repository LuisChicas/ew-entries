using EasyWallet.Entries.Business.Abstractions;
using EasyWallet.Entries.Data.Abstractions;
using EasyWallet.Entries.Data.Entities;
using System;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Business.Services
{
    public class EntryService : IEntryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddEntry(int keywordId, decimal amount, DateTime date)
        {
            DateTime now = DateTime.UtcNow;

            var entryDate = new DateTime(
                date.Year,
                date.Month,
                date.Day,
                now.Hour,
                now.Minute,
                now.Second);

            var entry = new EntryData
            {
                Amount = amount,
                KeywordId = keywordId,
                Date = entryDate,
                CreatedAt = DateTime.UtcNow
            };

            int entryId = await _unitOfWork.Entries.AddAsync(entry);
            await _unitOfWork.CommitAsync();

            return entryId;
        }

        public async Task DeleteEntry(int id)
        {
            var entryData = await _unitOfWork.Entries.GetActiveEntryById(id);

            if (entryData != null)
            {
                entryData.DeletedAt = DateTime.UtcNow;
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
