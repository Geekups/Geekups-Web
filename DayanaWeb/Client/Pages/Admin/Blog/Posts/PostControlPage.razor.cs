using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using MudBlazor;

namespace DayanaWeb.Client.Pages.Admin.Blog.Posts;

public partial class PostControlPage
{
    private IEnumerable<Post> pagedData;
    private MudTable<Post> table;
    private string searchString = "";
    private Post selectedItem = null;


    /// <summary>
    /// getting the paged, filtered and ordered data from the server
    /// </summary>
    private async Task<TableData<Post>> ServerReload(TableState state)
    {
        DefaultPaginationFilter paginationFilter = new(state.Page, state.PageSize);
        var paginatedData = await _httpService.GetPagedValue<Post>(Routes.Post + "get-post-category-list-by-filter", paginationFilter);
        pagedData = paginatedData.Data;
        return new TableData<Post>() { TotalItems = paginatedData.TotalCount, Items = pagedData };
    }

    private async Task OnCommitEdit()
    {
        await _httpService.PutValue(Routes.Post + "", selectedItem);
    }
    private async Task OnDelete(long id)
    {
        await _httpService.DeleteValue<Post>(Routes.Post + $"delete-post-category/{id}");
    }
    private void OnSearch(string text)
    {
        searchString = text;
        table.ReloadServerData();
    }

    private void Edit(long id)
    {
        _navigationManager.NavigateTo($"/cp-pc-edit/{id}");
    }
}
