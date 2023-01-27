using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.BaseControl;


public static class QueryableExtension
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {
        return query.Skip((page - 1) * pageSize).Take(pageSize);
    }
}