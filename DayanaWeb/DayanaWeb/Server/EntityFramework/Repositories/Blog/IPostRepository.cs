using DayanaWeb.Server.Basic.Classes;
using DayanaWeb.Server.EntityFramework.Common;
using DayanaWeb.Server.EntityFramework.Entities.Blog;
using DayanaWeb.Server.EntityFramework.Extensions.Blog;
using DayanaWeb.Shared.Basic.Classes;
using Microsoft.EntityFrameworkCore;

namespace DayanaWeb.Server.EntityFramework.Repositories.Blog;
public interface IPostRepository : IRepository<Post>
{
    Task<Post> GetPostByIdAsync(long id);
    Task<Post> GetPostByPostNameAsync(string Postname);
    Task<PaginatedList<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter);
}

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly IQueryable<Post> _queryable;

    public PostRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<Post>();
    }

    public async Task<Post> GetPostByIdAsync(long id)
    {
        var data = await _queryable
    .SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<Post>.NotFoundError("id").ToString());

        return data;
    }

    public async Task<Post> GetPostByPostNameAsync(string Postname)
    {
        var data = await _queryable
         .SingleOrDefaultAsync(x => x.Name.ToLower() == Postname.ToLower());

        if (data == null)
            throw new NullReferenceException(GenericErrors<Post>.NotFoundError("name").ToString());
        return data;
    }

    public async Task<PaginatedList<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter)
    {
        try
        {
            var query = _queryable;
            query = query.AsNoTracking();

            query = query.ApplyFilter(filter);
            query = query.ApplySort(filter.SortBy);

            var dataTotalCount = _queryable.Count();

            return new PaginatedList<Post>()
            {
                Data = await query.Paginate(filter.Page, filter.PageSize).ToListAsync(),
                TotalCount = dataTotalCount,
                TotalPages = (int)Math.Ceiling((decimal)dataTotalCount / (decimal)filter.PageSize),
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }
        catch (Exception)
        {

            throw;
        }
    }
}

