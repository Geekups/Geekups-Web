using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using MudBlazor;
using System.Net;

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

    private async Task OnDelete(long id)
    {
        var response = await _httpService.DeleteValue<PostCategory>(Routes.PostCategory + $"delete-post-category/{id}");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            _snackbar.Add("Post Category Deleted Succesfully", Severity.Success);
        }
        else
        {
            _snackbar.Add("Operation Failed", Severity.Error);
        }
    }
    private void OnSearch(string text)
    {
        searchString = text;
        table.ReloadServerData();
    }

    private void Edit(long id)
    {
        _navigationManager.NavigateTo($"/p-p-edit/{id}");
    }
}
