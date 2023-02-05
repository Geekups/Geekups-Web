using DayanaWeb.Shared.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DayanaWeb.Shared.Configs;

namespace DayanaWeb.Shared.EntityFramework.Entities.Blog;
public class Post : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }

    public int PostCategoryId { get; set; }
    public PostCategory PostCategory { get; set; }
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

        builder.HasOne<PostCategory>().WithMany(x => x.Posts).HasForeignKey(x=>x.PostCategoryId);
    }
}