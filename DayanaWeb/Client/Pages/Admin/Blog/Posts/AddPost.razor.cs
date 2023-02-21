using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;

namespace DayanaWeb.Client.Pages.Admin.Blog.Posts;

public partial class AddPost
{
    PostDto model = new();
    List<PostCategoryDto> categoryList = new();
    private long categorySelectedValue { get; set; }

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
