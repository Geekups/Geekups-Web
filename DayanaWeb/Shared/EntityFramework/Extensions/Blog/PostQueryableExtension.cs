using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;

namespace DayanaWeb.Shared.EntityFramework.Extensions.Blog;
public static class PostQueryableExtension
{
    public static IQueryable<Post> ApplyFilter(this IQueryable<Post> query, DefaultPaginationFilter filter)
    {
        // Filter By id
        if (filter.Id.HasValue)
            query = query.Where(x => x.Id == filter.Id.Value);

        // Filter By Value
        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.Name.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        return query;
    }

    public static IQueryable<Post> ApplySort(this IQueryable<Post> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            //SortByEnum.CreationDate => query.OrderBy(x => x.CreatedAt),
            //SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreatedAt),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}

