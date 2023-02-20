using MudBlazor;
using static MudBlazor.CategoryTypes;
using System.Net.Http;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class PostCategoryPage
{
    private IEnumerable<PostCategory> pagedData;
    private MudTable<PostCategory> table;
    private string searchString = "";
    private PostCategory selectedItem = null;
    

    /// <summary>
    /// getting the paged, filtered and ordered data from the server
    /// </summary>
    private async Task<TableData<PostCategory>> ServerReload(TableState state)
    {
        DefaultPaginationFilter paginationFilter = new(state.Page, state.PageSize);
        var paginatedData = await _httpService.GetPagedValue<PostCategory>(Routes.PostCategory + "get-post-category-list-by-filter", paginationFilter);
        pagedData = paginatedData.Data;
        return new TableData<PostCategory>() { TotalItems = paginatedData.TotalCount, Items = pagedData };
    }

    private async Task OnCommitEdit()
    {
        await _httpService.PutValue(Routes.PostCategory + "", selectedItem);
    }
    private async Task OnDelete(long id)
    {
        await _httpService.DeleteValue<PostCategory>(Routes.PostCategory + $"delete-post-category/{id}");
    }
    private void OnSearch(string text)
    {
        searchString = text;
        table.ReloadServerData();
    }
}
