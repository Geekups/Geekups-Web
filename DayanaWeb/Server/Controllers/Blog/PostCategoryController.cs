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
public class PostCategoryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PostCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [Route(Routes.PostCategory + "add-post-category")]
    [HttpPost]
    public async Task AddPostCategory([FromBody] string data)
    {
        var dto = JsonSerializer.Deserialize<PostCategoryDto>(data);
        var entity = _mapper.Map<PostCategory>(dto);
        await _unitOfWork.PostCategories.AddAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    [Route(Routes.PostCategory + "get-post-categories")]
    [HttpGet]
    public async Task<List<PostCategoryDto>> GetPostCategories()
    {
        var entityList = await _unitOfWork.PostCategories.GetPostCategoriesAsync();
        var dtoList = _mapper.Map<List<PostCategoryDto>>(entityList);

        return dtoList;
    }

    [Route(Routes.PostCategory + "get-post-category/{data}")]
    [HttpGet]
    public async Task<PostCategoryDto> GetPostCategory([FromRoute] long data)
    {
        var entity = await _unitOfWork.PostCategories.GetPostCategoryByIdAsync(data);
        var dto = _mapper.Map<PostCategoryDto>(entity);
        return dto;
    }

    [Route(Routes.PostCategory + "get-post-category-list-by-filter")]
    [HttpGet]
    public async Task<List<PostCategoryDto>> GetPostCategoryListByFilter([FromBody] DefaultPaginationFilter data)
    {
        var entityList = await _unitOfWork.PostCategories.GetPostCategoriesByFilterAsync(data);
        var dtoList = _mapper.Map<List<PostCategoryDto>>(entityList);
        return dtoList;
    }

    [Route(Routes.PostCategory + "delete-post-category/{data}")]
    [HttpDelete]
    public async Task DeletePostCategory([FromRoute] long data)
    {
        var entity = await _unitOfWork.PostCategories.GetPostCategoryByIdAsync(data);
        _unitOfWork.PostCategories.Remove(entity);
        await _unitOfWork.CommitAsync();
    }

    [Route(Routes.PostCategory + "update-post-category")]
    [HttpPut]
    public async Task UpdatePostCategory([FromBody] PostCategoryDto data)
    {
        var entity = _mapper.Map<PostCategory>(data);
        _unitOfWork.PostCategories.Update(entity);
        await _unitOfWork.CommitAsync();
    }
}

