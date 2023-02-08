using DayanaWeb.Shared.Configs;
using DayanaWeb.Shared.EntityFramework.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DayanaWeb.Shared.EntityFramework.Entities.Blog;
public class PostCategory : BaseEntity
{
    public string Name { get; set; }
    public List<Post> Posts { get; set; }
}

public class PostCategoryEntityConfiguration : IEntityTypeConfiguration<PostCategory>
{
    public void Configure(EntityTypeBuilder<PostCategory> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(DefaultNumbers.NameLength);

        #endregion
    }
}