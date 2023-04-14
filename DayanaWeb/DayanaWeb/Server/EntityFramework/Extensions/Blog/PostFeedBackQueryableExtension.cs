﻿using DayanaWeb.Server.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Basic.Classes;

namespace DayanaWeb.Server.EntityFramework.Extensions.Blog;
public static class PostFeedBackQueryableExtension
{
    public static IQueryable<PostFeedBack> ApplyFilter(this IQueryable<PostFeedBack> query, DefaultPaginationFilter filter)
    {
        if (!string.IsNullOrEmpty(filter.Keyword))
            query = query.Where(x => x.CommentText.ToLower().Contains(filter.Keyword.ToLower().Trim()));

        //if (!string.IsNullOrEmpty(filter.Title))
        //    query = query.Where(x => x.Name.ToLower().Contains(filter.Title.ToLower().Trim()));

        return query;
    }

    public static IQueryable<PostFeedBack> ApplySort(this IQueryable<PostFeedBack> query, SortByEnum? sortBy)
    {
        return sortBy switch
        {
            SortByEnum.CreationDate => query.OrderBy(x => x.CreateDate),
            SortByEnum.CreationDateDescending => query.OrderByDescending(x => x.CreateDate),
            _ => query.OrderByDescending(x => x.Id)
        };
    }
}
