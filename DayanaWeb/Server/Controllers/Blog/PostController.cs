using AutoMapper;
using DayanaWeb.Shared.BaseControl;
using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DayanaWeb.Server.Controllers.Blog;
[ApiController]
public class PostController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PostController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [Route(Routes.Post + "add-post")]
    [HttpPost]
    public async Task AddPost([FromBody] string data)
    {
        var dto = JsonSerializer.Deserialize<PostDto>(data);
        var entity = _mapper.Map<Post>(dto);
        await _unitOfWork.Posts.AddAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    [Route(Routes.Post + "get-post/{data}")]
    [HttpGet]
    public async Task<PostDto> GetPost([FromRoute] long data)
    {
        var entity = await _unitOfWork.Posts.GetPostByIdAsync(data);
        var dto = _mapper.Map<PostDto>(entity);
        return dto;
    }

    [Route(Routes.Post + "get-post-list-by-filter")]
    [HttpGet]
    public async Task<List<PostDto>> GetPostListByFilter([FromBody] DefaultPaginationFilter data)
    {
        var entityList = await _unitOfWork.Posts.GetPostsByFilterAsync(data);
        var dtoList = _mapper.Map<List<PostDto>>(entityList);
        return dtoList;
    }

    [Route(Routes.Post + "delete-post/{data}")]
    [HttpDelete]
    public async Task DeletePost([FromRoute] long data)
    {
        var entity = await _unitOfWork.Posts.GetPostByIdAsync(data);
        _unitOfWork.Posts.Remove(entity);
        await _unitOfWork.CommitAsync();
    }

    [Route(Routes.Post + "update-post")]
    [HttpPut]
    public async Task UpdatePost([FromBody] PostDto data)
    {
        var entity = _mapper.Map<Post>(data);
        _unitOfWork.Posts.Update(entity);
        await _unitOfWork.CommitAsync();
    }
}
