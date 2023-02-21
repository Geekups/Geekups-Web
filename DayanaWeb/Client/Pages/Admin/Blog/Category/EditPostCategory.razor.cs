using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;
using Microsoft.AspNetCore.Components;

namespace DayanaWeb.Client.Pages.Admin.Blog.Category;

public partial class EditPostCategory
{
    [Parameter]
    public string Id { get; set; }
    PostCategoryDto model = new();
    protected override async Task OnInitializedAsync()
    {
        model = await _httpService.GetValue<PostCategoryDto>(Routes.PostCategory + $"get-post-category/{Id}");
        var aa = 3;
    }

    private async Task OnEdit()
    {
        await _httpService.PutValue(Routes.PostCategory + "update-post-category", model);
    }
}
