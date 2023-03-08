using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.EntityFramework.Extensions.Blog;
using Microsoft.EntityFrameworkCore;

namespace DayanaWeb.Shared.EntityFramework.Repositories.Blog;

public interface IPostFeedBackRepository : IRepository<PostFeedBack>
{
    Task<PostFeedBack> GetPostFeedBackByIdAsync(long id);
    Task<PaginatedList<PostFeedBack>> GetPostFeedBacksByFilterAsync(DefaultPaginationFilter filter);
}


public class PostFeedBackRepository : Repository<PostFeedBack>, IPostFeedBackRepository
{
    private readonly IQueryable<PostFeedBack> _queryable;

    public PostFeedBackRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<PostFeedBack>();
    }

    public async Task<PostFeedBack> GetPostFeedBackByIdAsync(long id)
    {
        var data = await _queryable.SingleOrDefaultAsync(x => x.Id == id);

        if (data == null)
            throw new NullReferenceException(GenericErrors<PostFeedBack>.NotFoundError("id").ToString());

        return data;
    }

    public async Task<PaginatedList<PostFeedBack>> GetPostFeedBacksByFilterAsync(DefaultPaginationFilter filter)
    {
        var query = _queryable;
        query = query.AsNoTracking();

        query = query.ApplyFilter(filter);
        query = query.ApplySort(filter.SortBy);
        var dataTotalCount = _queryable.Count();

        return new PaginatedList<PostFeedBack>()
        {
            Data = await query.Paginate(filter.Page, filter.PageSize).ToListAsync(),
            TotalCount = dataTotalCount,
            TotalPages = (int)Math.Ceiling((decimal)dataTotalCount / (decimal)filter.PageSize),
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }
}
