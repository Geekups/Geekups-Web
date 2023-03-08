using DayanaWeb.Shared.Configs;
using DayanaWeb.Shared.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayanaWeb.Shared.EntityFramework.Entities.Blog;
public class Post : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }

    public long PostCategoryId { get; set; }
    public PostCategory PostCategory { get; set; }
    public List<PostFeedBack> PostFeedBacks { get; set; }
}

public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(DefaultNumbers.NameLength);

        builder.Property(e => e.Description).IsRequired().HasMaxLength(DefaultNumbers.ShortDescriptionLength);

        builder.Property(e => e.Author).IsRequired().HasMaxLength(DefaultNumbers.NameLength);

        #endregion

        builder.HasOne(x=>x.PostCategory).WithMany(x => x.Posts)
            .HasForeignKey(x => x.PostCategoryId).OnDelete(DeleteBehavior.NoAction);
    }
}