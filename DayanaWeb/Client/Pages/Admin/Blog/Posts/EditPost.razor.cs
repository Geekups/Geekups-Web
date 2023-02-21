using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using Microsoft.AspNetCore.Components;

namespace DayanaWeb.Client.Pages.Admin.Blog.Posts;

public partial class EditPost
{
    [Parameter]
    public string Id { get; set; }
    PostDto model = new();
    List<PostCategoryDto> categoryList = new();
    private long categorySelectedValue { get; set; }
    protected override async Task OnInitializedAsync()
    {
        model = await _httpService.GetValue<PostDto>(Routes.Post + $"get-post/{Id}");
        categoryList = await _httpService.GetValueList<PostCategoryDto>(Routes.PostCategory + "get-post-categories");
    }

    private async Task OnEdit()
    {
        await _httpService.PutValue(Routes.Post + "update-post", model);
    }
}
