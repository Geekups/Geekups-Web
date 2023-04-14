﻿using DayanaWeb.Shared.EntityFramework.Common;

namespace DayanaWeb.Shared.EntityFramework.DTO.Blog;
public class PostDto : BaseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }

    public long PostCategoryId { get; set; }
    public PostCategoryDto PostCategoryDto { get; set; }
}