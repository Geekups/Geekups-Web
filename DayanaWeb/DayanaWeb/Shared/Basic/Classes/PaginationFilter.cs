namespace DayanaWeb.Shared.Basic.Classes;

public class PaginationFilter
{
    private const int MinPageNumber = 1;
    private const int MaxPageSize = 200;

    protected PaginationFilter(int pageNumber, int pageSize)
    {
        Page = pageNumber > 0 ? pageNumber : MinPageNumber;
        PageSize = pageSize > 0 && pageSize <= MaxPageSize ? pageSize : MaxPageSize;
    }

    protected PaginationFilter()
    {
    }

    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPageCount { get; set; }
}

public class DefaultPaginationFilter : PaginationFilter
{
    public DefaultPaginationFilter(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    public DefaultPaginationFilter() { }

    public string? Keyword { get; set; }
    public int? IntValue { get; set; }
    public string? StringValue { get; set; }
    public IEnumerable<int>? IntValueList { get; set; }
    public IEnumerable<string>? StringValueList { get; set; }
    public string? Title { get; set; }
    public SortByEnum? SortBy { get; set; }
}