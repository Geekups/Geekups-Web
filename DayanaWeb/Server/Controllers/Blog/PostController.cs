using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace DayanaWeb.Server.Controllers.Blog;
[ApiController]
public class PostController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public PostController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //[Route(Routes.Post + "add-post")]
    //[HttpPost]
    //public async HttpResponse AddPost([FromBody]PostDto postDto)
    //{

    //}
}
