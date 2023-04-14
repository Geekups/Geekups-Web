using AutoMapper;
using DayanaWeb.Server.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Basic.Classes;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;

namespace DayanaWeb.Server.Basic.Classes;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<PostCategory, PostCategoryDto>().ReverseMap();
        CreateMap<PaginatedList<PostCategory>, PaginatedList<PostCategoryDto>>().ReverseMap();
    }
}