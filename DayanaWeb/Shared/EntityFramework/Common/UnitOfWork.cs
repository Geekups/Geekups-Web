using DayanaWeb.Shared.EntityFramework.Repositories.Blog;

namespace DayanaWeb.Shared.EntityFramework.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public IPostRepository Posts { get; }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public UnitOfWork(DataContext context)
    {
        _context = context;
        Posts = new PostRepository(_context);
    }
}
