using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class AddPostCategory
{
    PostCategoryDto model = new();

    public async Task Add()
    {
        await _httpService.PostValue(Routes.PostCategory + "add-post-category", model);
    }
}

