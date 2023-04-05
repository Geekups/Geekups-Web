using DayanaWeb.Shared.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayanaWeb.Shared.EntityFramework.Entities.Blog;
public class PostFeedBack : BaseEntity
{
    public string? CommentText { get; set; }
    // public bool IsReply { get; set; }
    // public bool IsLiked { get; set; }
    #region Navigations

    public long PostId { get; set; }
    public Post Post { get; set; }

    //public int CommentOwnerId { get; set; }
    //public User CommentOwner { get; set; }

    //public int? ReplyToCommentId { get; set; }
    #endregion
}


public class PostCommentEntityConfiguration : IEntityTypeConfiguration<PostFeedBack>
{
    public void Configure(EntityTypeBuilder<PostFeedBack> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        //builder.Property(e => e.CommentText)
        //    .IsRequired().HasMaxLength(DefaultNumbers.LongLength1);
        #endregion

        #region Navigations

        builder.HasOne(e => e.Post).WithMany(e => e.PostFeedBacks).HasForeignKey(e => e.PostId);
        // builder.HasOne(e => e.CommentOwner).WithMany(e => e.PostComments)
        // .HasForeignKey(e => e.CommentOwnerId).OnDelete(DeleteBehavior.NoAction); ;
        #endregion
    }
}