using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class PostCategoryPage
{
    List<PostCategory> model = new();
    PaginatedList<PostCategory> paginationData = new();
    DefaultPaginationFilter paginationFilter = new(1,10);

    protected override async Task OnInitializedAsync()
    {
        var paginatedList = await _httpService.GetPagedValue<PostCategory>(Routes.PostCategory + "get-post-category-list-by-filter",paginationFilter);
        model = paginatedList.Data;
        paginationData = paginatedList;
    }
}
