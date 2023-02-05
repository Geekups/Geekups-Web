using DayanaWeb.Shared.EntityFramework.Common;

namespace DayanaWeb.Shared.EntityFramework.DTO.Blog;

public class PostCategoryDto : BaseDto
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public List<PostDto> PostDtos { get; set; }
}

