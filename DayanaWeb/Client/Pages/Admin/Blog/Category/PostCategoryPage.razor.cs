using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;
using MudBlazor;
using static MudBlazor.CategoryTypes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class PostCategoryPage
{
    MudTable<PostCategory> _table = new();
    private IEnumerable<PostCategory> _elements = new List<PostCategory>();
    int _totalItems = 0;

    int _selectedPage = 1;
    PaginatedList<PostCategory> paginationData = new();

    protected override async Task OnInitializedAsync()
    {
        var paginatedList = await GetPaginatedListAsync(_selectedPage);
        paginationData = paginatedList;
        _elements = paginatedList.Data;
        _totalItems = paginatedList.TotalCount;
    }

    private async Task<PaginatedList<PostCategory>> GetPaginatedListAsync(int selectedPage)
    {
        DefaultPaginationFilter paginationFilter = new(selectedPage, 10);
        return await _httpService.GetPagedValue<PostCategory>(Routes.PostCategory + "get-post-category-list-by-filter", paginationFilter);
    }

    private async void PageChanged(int i)
    {
        _elements = (await GetPaginatedListAsync(i)).Data;
        _table.NavigateTo(i);
    }
}
