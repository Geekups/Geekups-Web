using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog.Post;

public partial class AddPost
{
    PostDto model = new();
    List<PostCategoryDto> categoryList = new();
    private long categorySelectedValue {  get; set; }

    protected override async Task OnInitializedAsync()
    {
        categoryList = await _httpService.GetValueList<PostCategoryDto>(Routes.PostCategory + "get-post-categories");
    }

    protected async Task Add()
    {
        model.PostCategoryId = categorySelectedValue;
        await _httpService.PostValue(Routes.Post + "add-post", model);
    }
}
