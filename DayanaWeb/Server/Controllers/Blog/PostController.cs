using AutoMapper;
using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;
using Microsoft.AspNetCore.Mvc;

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
    public async Task AddPost([FromBody] PostDto postDto)
    {
        var entity = _mapper.Map<Post>(postDto);
        await _unitOfWork.Posts.AddAsync(entity);
    }
}
