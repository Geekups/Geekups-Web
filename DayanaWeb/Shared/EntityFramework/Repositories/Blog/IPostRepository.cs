using DayanaWeb.Shared.EntityFramework.Common;
using DayanaWeb.Shared.EntityFramework.DTO.Blog;
using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.EntityFramework.Repositories.Blog;
public interface IPostRepository : IRepository<Post>
{
    Task<Post> GetPostByIdAsync(int id);
    Task<Post> GetPostByPostnameAsync(string Postname);
    //Task<List<Post>> GetPostsByFilterAsync(DefaultPaginationFilter filter);
}

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly IQueryable<Post> _queryable;

    public PostRepository(DataContext context) : base(context)
    {
        _queryable = DbContext.Set<Post>();
    }

    public Task<Post> GetPostByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetPostByPostnameAsync(string Postname)
    {
        throw new NotImplementedException();
    }
}

