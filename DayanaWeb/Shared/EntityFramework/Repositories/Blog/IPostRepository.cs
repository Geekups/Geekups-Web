using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            throw new NullReferenceException(GenericErrors<PostCategory>.NotFoundError("id").ToString());

        return data;
    }

    public Task<Post> GetPostByPostnameAsync(string Postname)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;
        // Filter By id
        if (filter.Id.HasValue)
            query = _queryable.Where(x => x.Id == filter.Id.Value);

        // Filter By Value
        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.Name.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }
}

