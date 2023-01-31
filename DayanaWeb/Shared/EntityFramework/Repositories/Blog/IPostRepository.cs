using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.EntityFramework.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace DayanaWeb.Shared.EntityFramework.Repositories.Blog;
public interface IPostRepository : IRepository<Post>
{
    Task<Post> GetPostByIdAsync(int id);
    Task<Post> GetPostByPostnameAsync(string Postname);
    Task<List<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter);
}

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly IQueryable<Post> _queryable;

    public PostRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<Post>();
    }

    public async Task<Post> GetPostByIdAsync(int id)
    {
        var data = await _queryable
    .SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<Post>.NotFoundError("id").ToString());

        return data;
    }

    public async Task<Post> GetPostByPostnameAsync(string Postname)
    {
        var data = await _queryable
         .SingleOrDefaultAsync(x => x.Name.ToLower() == Postname.ToLower());

        if (data == null)
            throw new NullReferenceException(GenericErrors<Post>.NotFoundError("name").ToString());
        return data;
    }

    public async Task<List<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;
        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }
}

