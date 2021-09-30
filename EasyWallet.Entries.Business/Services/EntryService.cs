using EasyWallet.Entries.Business.Abstractions;
using EasyWallet.Entries.Business.Helpers;
using EasyWallet.Entries.Business.Models;
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

        public async Task<int> AddEntry(Entry entry)
        {
            DateTime now = DateTime.UtcNow;

            var entryDate = new DateTime(
                entry.Date.Year,
                entry.Date.Month,
                entry.Date.Day,
                now.Hour,
                now.Minute,
                now.Second);

            entry.Date = entryDate;
            entry.CreatedAt = DateTime.UtcNow;

            EntryData entryData = BusinessMapper.Map<EntryData>(entry);

            await _unitOfWork.Entries.AddAsync(entryData);
            await _unitOfWork.CommitAsync();

            return entryData.Id;
        }

        public async Task<int> AddEntry(int userId, int keywordId, decimal amount, DateTime date)
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
                UserId = userId,
                KeywordId = keywordId,
                Amount = amount,
                Date = entryDate,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Entries.AddAsync(entry);
            await _unitOfWork.CommitAsync();

            return entry.Id;
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
