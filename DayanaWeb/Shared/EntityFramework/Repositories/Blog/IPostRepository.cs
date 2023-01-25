using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.EntityFramework.Repositories.Blog;
public interface IPostRepository
{
        public Task AddPost(PostDto dto);
}

public class PostRepository : IPostRepository
{
    private DataContext _dataContext;
    private DbSet<Post> _posts;

    public PostRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        _posts = _dataContext.Set<Post>();
    }

    public async Task AddPost(PostDto dto)
    {
        var entity = new Post
        {
            Name = dto.Name,
            ModifiedDate = dto.ModifiedDate,
            CreateDate = dto.CreateDate,
        };
        await _posts.AddAsync(entity);
    }
}

