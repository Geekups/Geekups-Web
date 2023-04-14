﻿using DayanaWeb.Shared.EntityFramework.Common;

namespace DayanaWeb.Shared.EntityFramework.DTO.Blog;
public class PostFeedBackDto : BaseDto
{
    public string CommentText { get; set; }
    //public bool IsReplyToAnotherComment { get; set; }
    //public bool IsLiked { get; set; }
    #region Navigations

    public long PostId { get; set; }
    public PostDto PostDto { get; set; }

    //public int CommentOwnerId { get; set; }
    //public User CommentOwner { get; set; }

    //public int? ReplyToCommentId { get; set; }
    #endregion
}
