namespace DayanaWeb.Shared.BaseControl;


public static class QueryableExtension
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int pageSize) where T : class
    {
        return query.Skip((page - 1) * pageSize).Take(pageSize);
    }

    public static List<T> Paginate<T>(this List<T> query, int page, int pageSize) where T : class
    {
        return (List<T>)query.Skip((page - 1) * pageSize).Take(pageSize);
    }
}