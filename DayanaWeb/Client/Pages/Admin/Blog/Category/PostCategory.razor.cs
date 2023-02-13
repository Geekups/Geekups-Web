using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class PostCategory
{
    List<PostCategoryDto> model = new();
    DefaultPaginationFilter paginationFilter = new();
    protected override async Task OnInitializedAsync()
    {
        var paginatedList = await _httpService.GetPagedValue<PostCategoryDto>(Routes.PostCategory + "get-post-category-list-by-filter",paginationFilter);
        model = paginatedList.Data;
    }
}
