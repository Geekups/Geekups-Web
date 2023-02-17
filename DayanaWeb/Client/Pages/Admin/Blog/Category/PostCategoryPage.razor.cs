using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class PostCategoryPage
{
    int _selectedPage = 1;
    List<PostCategory> model = new();
    PaginatedList<PostCategory> paginationData = new();

    protected override async Task OnInitializedAsync()
    {
        var paginatedList = await GetPaginatedListAsync(); 
        model = paginatedList.Data;
        paginationData = paginatedList;
    }

    private async Task<PaginatedList<PostCategory>> GetPaginatedListAsync()
    {
        DefaultPaginationFilter paginationFilter = new(_selectedPage, 10);
        return await _httpService.GetPagedValue<PostCategory>(Routes.PostCategory + "get-post-category-list-by-filter", paginationFilter);
    }

    private async Task ChangePageAsync(EventArgs eventArgs)
    {
        eventArgs
    }
}
