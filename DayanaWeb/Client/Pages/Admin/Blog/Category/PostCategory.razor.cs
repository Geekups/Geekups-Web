using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class PostCategory
{
    List<PostCategoryDto> model = new();
    protected override async Task OnInitializedAsync()
    {
        model = await _httpService.GetValueList<PostCategoryDto>(Routes.PostCategory + "get-post-category-list-by-filter");
    }
}
