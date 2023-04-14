using DayanaWeb.Server.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Basic.Classes;
using static MudBlazor.CategoryTypes;

namespace DayanaWeb.Server.EntityFramework.Extensions.Blog;
public static class PostQueryableExtension
{
    public static IQueryable<Post> ApplyFilter(this IQueryable<Post> query, DefaultPaginationFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Keyword))
            query = query.Where(x => x.Description.ToLower().Contains(filter.Keyword.ToLower().Trim()));

        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => x.Content.ToLower().Contains(filter.StringValue.ToLower().Trim()));

        if (!string.IsNullOrEmpty(filter.Title))
            query = query.Where(x => x.Name.ToLower().Contains(filter.Title.ToLower().Trim()));

        return query;
    }

    public static IQueryable<Post> ApplySort(this IQueryable<Post> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreateDate),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreateDate),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}

