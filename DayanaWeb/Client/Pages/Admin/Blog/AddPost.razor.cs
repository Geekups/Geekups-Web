using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog;

public partial class AddPost
{
    PostDto model = new();

    public async Task Add()
    {
        await _httpService.PostValue(Routes.Post + "add-post", model);
    }
}
