using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;

namespace DayanaWeb.Client.Pages.Admin.Blog
{
    public partial class AddPost
    {
        public PostDto PostDtoData { get; set; }

        public async Task AddNewPost()
        {
            await _httpService.PostValue(Routes.Post + "add-post", PostDtoData);
        }
    }
}
