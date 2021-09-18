﻿using System;
using System.Threading.Tasks;

namespace EasyWallet.Entries.Data.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        /*
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }
        ITagRepository Tags { get; }
        */

        IEntryRepository Entries { get; }

        Task<int> CommitAsync();
    }
}
