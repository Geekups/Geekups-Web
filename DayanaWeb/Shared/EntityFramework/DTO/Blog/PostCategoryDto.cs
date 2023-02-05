using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.EntityFramework.DTO.Blog;

public class PostCategoryDto: BaseDto
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public List<PostDto> PostDtos { get; set; }
}

