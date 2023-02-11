using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.EntityFramework.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace DayanaWeb.Shared.EntityFramework.Repositories.Blog;

public interface IPostCategoryRepository : IRepository<PostCategory>
{
    Task<PostCategory> GetPostCategoryByIdAsync(int id);
    Task<PostCategory> GetPostCategoryByPostCategoryNameAsync(string PostCategoryname);
    Task<List<PostCategory>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter);
    Task<List<PostCategory>> GetPostCategoriesAsync();
}


public class PostCategoryRepository : Repository<PostCategory>, IPostCategoryRepository
{
    private readonly IQueryable<PostCategory> _queryable;

    public PostCategoryRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<PostCategory>();
    }

    public async Task<PostCategory> GetPostCategoryByIdAsync(int id)
    {
        var data = await _queryable
    .SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostCategory>.NotFoundError("id").ToString());

        return data;
    }

    public async Task<PostCategory> GetPostCategoryByPostCategoryNameAsync(string PostCategoryname)
    {
        var data = await _queryable
         .SingleOrDefaultAsync(x => x.Name.ToLower() == PostCategoryname.ToLower());

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostCategory>.NotFoundError("name").ToString());
        return data;
    }

    public async Task<List<PostCategory>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;
        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);

        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
    }

    public async Task<List<PostCategory>> GetPostCategoriesAsync()
    {
        return await _queryable.ToListAsync();
    }
}

