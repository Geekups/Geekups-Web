using AutoMapper;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;

namespace DayanaWeb.Shared.Configs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<PostCategory, PostCategoryDto>().ReverseMap();
    }
}