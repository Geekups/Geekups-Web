﻿using DayanaWeb.Shared.EntityFramework.Repositories.Blog;

namespace DayanaWeb.Shared.EntityFramework.Common;
public interface IUnitOfWork : IDisposable
{
    IPostRepository Posts { get; }

    Task<bool> CommitAsync();

}