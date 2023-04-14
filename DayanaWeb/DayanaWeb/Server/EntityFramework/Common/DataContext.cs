using Microsoft.EntityFrameworkCore;

namespace DayanaWeb.Server.EntityFramework.Common;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("dbo");
        var assembly = typeof(IBaseEntity).Assembly;
        modelBuilder.RegisterAllEntities<IBaseEntity>(assembly);
        modelBuilder.RegisterEntityTypeConfiguration(assembly);

    }
}