namespace DayanaWeb.Server.EntityFramework.Common;
public interface IUnitOfWork : IDisposable
{
    //IProductCategoryRepository ProductCategories { get; }
    //IProductRepository Products { get; }
    Task<bool> CommitAsync();
}

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    //public IProductCategoryRepository ProductCategories { get; }
    //public IProductRepository Products { get; }

    public async Task<bool> CommitAsync() => await _context.SaveChangesAsync() > 0;
    public void Dispose() => _context.Dispose();

    public UnitOfWork(DataContext context)
    {
        _context = context;
        //ProductCategories = new ProductCategoryRepository(_context);
        //Products = new ProductRepository(_context);
    }
}
