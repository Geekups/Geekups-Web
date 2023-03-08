using DayanaWeb.Shared.EntityFramework.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayanaWeb.Shared.EntityFramework.DTO.Blog;
public class PostFeedBackDto
{
    public string CommentText { get; set; }
    //public bool IsReplyToAnotherComment { get; set; }
    public bool IsLiked { get; set; }
    #region Navigations

    public int PostId { get; set; }
    public PostDto PostDto { get; set; }

    //public int CommentOwnerId { get; set; }
    //public User CommentOwner { get; set; }

    //public int? ReplyToCommentId { get; set; }
    #endregion
}
