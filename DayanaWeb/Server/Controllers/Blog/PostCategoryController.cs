﻿using AutoMapper;
using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using DayanaWeb.Shared.Infrastructure.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
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
}

