using DayanaWeb.Server.EntityFramework.Common;
using DayanaWeb.Server.EntityFramework.Entities.Blog;
using DayanaWeb.Server.EntityFramework.Extensions.Blog;
using DayanaWeb.Shared.Basic.Classes;
using Microsoft.EntityFrameworkCore;

namespace DayanaWeb.Server.EntityFramework.Repositories.Blog;

public interface IPostCategoryRepository : IRepository<PostCategory>
{
    Task<PostCategory> GetPostCategoryByIdAsync(long id);
    Task<PostCategory> GetPostCategoryByPostCategoryNameAsync(string PostCategoryName);
    Task<PaginatedList<PostCategory>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter);
    Task<List<PostCategory>> GetPostCategoriesAsync();
}


public class PostCategoryRepository : Repository<PostCategory>, IPostCategoryRepository
{
    private readonly IQueryable<PostCategory> _queryable;

    public PostCategoryRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<PostCategory>();
    }

    public async Task<PostCategory> GetPostCategoryByIdAsync(long id)
    {
        var data = await _queryable
    .SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostCategory>.NotFoundError("id").ToString());

        return data;
    }

    public async Task<PostCategory> GetPostCategoryByPostCategoryNameAsync(string PostCategoryName)
    {
        var data = await _queryable
         .SingleOrDefaultAsync(x => x.Name.ToLower() == PostCategoryName.ToLower());

        return data ?? throw new NullReferenceException(GenericErrors<PostCategory>.NotFoundError("name").ToString());
    }

    public async Task<PaginatedList<PostCategory>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;
        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);
        var dataTotalCount = _queryable.Count();

        return new PaginatedList<PostCategory>()
        {
            Data = await query.Paginate(filter.Page, filter.PageSize).ToListAsync(),
            TotalCount = dataTotalCount,
            TotalPages = (int)Math.Ceiling((decimal)dataTotalCount / (decimal)filter.PageSize),
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<List<PostCategory>> GetPostCategoriesAsync()
    {
        return await _queryable.ToListAsync();
    }

    // play ground
    public IEnumerable<PostCategory> GetPostCategories()
    {
        IEnumerable<PostCategory> enumerable = _queryable.AsEnumerable();
        yield return (PostCategory)enumerable;
    }
}

