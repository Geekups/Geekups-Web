namespace DayanaWeb.Shared.BaseControl;

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
    public IEnumerable<int>? StringValueList { get; set; }
    public int? CategoryId { get; set; }
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public SortByEnum? SortBy { get; set; }
}


public class CustomizedPaginationFilterOne<T1> : PaginationFilter
{
    public CustomizedPaginationFilterOne(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    public CustomizedPaginationFilterOne() { }

    public string? Keyword { get; set; }
    public int? IntValue { get; set; }
    public string? StringValue { get; set; }
    public IEnumerable<int>? IntValueList { get; set; }
    public IEnumerable<int>? StringValueList { get; set; }
    public int? CategoryId { get; set; }
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public SortByEnum? SortBy { get; set; }
    public T1 Value1 { get; set; }
}


public class CustomizedPaginationFilterTwo<T1, T2> : PaginationFilter
{
    public CustomizedPaginationFilterTwo(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    public CustomizedPaginationFilterTwo() { }

    public string? Keyword { get; set; }
    public int? IntValue { get; set; }
    public string? StringValue { get; set; }
    public IEnumerable<int>? IntValueList { get; set; }
    public IEnumerable<int>? StringValueList { get; set; }
    public int? CategoryId { get; set; }
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public SortByEnum? SortBy { get; set; }
    public T1 Value1 { get; set; }
    public T2 Value2 { get; set; }
}

public class CustomizedPaginationFilterThree<T1, T2, T3> : PaginationFilter
{
    public CustomizedPaginationFilterThree(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    public CustomizedPaginationFilterThree() { }

    public string? Keyword { get; set; }
    public int? IntValue { get; set; }
    public string? StringValue { get; set; }
    public IEnumerable<int>? IntValueList { get; set; }
    public IEnumerable<int>? StringValueList { get; set; }
    public int? CategoryId { get; set; }
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public SortByEnum? SortBy { get; set; }
    public T1 Value1 { get; set; }
    public T2 Value2 { get; set; }
    public T3 Valu32 { get; set; }
}


public class CustomizedPaginationFilterfour<T1, T2, T3, T4> : PaginationFilter
{
    public CustomizedPaginationFilterfour(int pageNumber, int pageSize) : base(pageNumber, pageSize) { }
    public CustomizedPaginationFilterfour() { }

    public string? Keyword { get; set; }
    public int? IntValue { get; set; }
    public string? StringValue { get; set; }
    public IEnumerable<int>? IntValueList { get; set; }
    public IEnumerable<int>? StringValueList { get; set; }
    public int? CategoryId { get; set; }
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public SortByEnum? SortBy { get; set; }
    public T1 Value1 { get; set; }
    public T2 Value2 { get; set; }
    public T3 Valu3 { get; set; }
    public T4 Value4 { get; set; }
}