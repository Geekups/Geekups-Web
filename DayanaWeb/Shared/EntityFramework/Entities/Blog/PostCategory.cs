using DayanaWeb.Shared.EntityFramework.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayanaWeb.Shared.Configs;

namespace DayanaWeb.Shared.EntityFramework.Entities.Blog;
public class PostCategory : BaseEntity
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public List<Post> Posts { get; set; }
}

public class PostCategoryEntityConfiguration : IEntityTypeConfiguration<PostCategory>
{
    public void Configure(EntityTypeBuilder<PostCategory> builder)
    {
        #region Properties features

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(DefaultNumbers.NameLength);

        builder.Property(e => e.Icon).IsRequired().HasMaxLength(DefaultNumbers.ShortLength6);

        #endregion
    }
}