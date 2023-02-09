using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Post;

public partial class AddPost
{
    PostDto model = new();
    List<PostCategoryDto> categoryList = new();

    protected override async Task OnInitializedAsync()
    {
        categoryList = await _httpService.GetValueList<PostCategoryDto>(Routes.PostCategory);
    }

    protected async Task Add()
    {
        await _httpService.PostValue(Routes.Post + "add-post", model);
    }
}