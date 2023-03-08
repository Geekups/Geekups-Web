﻿using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.EntityFramework.Extensions.Blog;
public static class PostFeedBackQueryableExtension
{
    public static IQueryable<PostFeedBack> ApplyFilter(this IQueryable<PostFeedBack> query, DefaultPaginationFilter filter)
    {
        // Filter By id
        if (filter.Id.HasValue)
            query = query.Where(x => x.Id == filter.Id.Value);

        // Filter By Value
        if (!string.IsNullOrEmpty(filter.StringValue))
            query = query.Where(x => (x.CommentText ?? "").ToLower().Contains(filter.StringValue.ToLower().Trim()));

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