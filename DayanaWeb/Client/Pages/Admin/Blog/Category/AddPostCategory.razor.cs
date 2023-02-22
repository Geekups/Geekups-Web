using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class AddPostCategory
{
    PostCategoryDto model = new();

    public async Task Add()
    {
        await _httpService.PostValue(Routes.PostCategory + "add-post-category", model);
    }
}

