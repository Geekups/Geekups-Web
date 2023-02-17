﻿using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.EntityFramework.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace DayanaWeb.Shared.EntityFramework.Repositories.Blog;

public interface IPostCategoryRepository : IRepository<PostCategory>
{
    Task<PostCategory> GetPostCategoryByIdAsync(long id);
    Task<PostCategory> GetPostCategoryByPostCategoryNameAsync(string PostCategoryName);
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

        return data == null ? throw new NullReferenceException(GenericErrors<PostCategory>.NotFoundError("name").ToString()) : data;
    }

    public async Task<List<PostCategory>> GetPostCategoriesByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;
        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);
        var totalPageCount = (int)Math.Ceiling((decimal)(_queryable.Count() / filter.PageSize));
        return await query.Paginate(filter.Page, filter.PageSize).ToListAsync();
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

