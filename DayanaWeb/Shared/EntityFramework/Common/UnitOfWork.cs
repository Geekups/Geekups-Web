using DayanaWeb.Shared.EntityFramework.Repositories.Blog;

namespace DayanaWeb.Shared.EntityFramework.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public IPostRepository Posts { get; }

    public Task<bool> CommitAsync()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public UnitOfWork(DataContext context)
    {
        _context = context;
        Posts = new PostRepository(_context);
    }
}
