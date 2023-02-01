using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog
{
    public partial class AddPost
    {
        PostDto postDto = new();

        public async Task AddNewPost()
        {
            await _httpService.PostValue(Routes.Post + "add-post", postDto);
        }
    }
}
