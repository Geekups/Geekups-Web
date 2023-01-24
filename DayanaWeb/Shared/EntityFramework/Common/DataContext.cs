using Microsoft.EntityFrameworkCore;

namespace DayanaWeb.Shared.EntityFramework.Common;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }


    //define entities here
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("dbo");

        var assembly = typeof(IBaseEntity).Assembly;
        //dbset entities
        modelBuilder.RegisterAllEntities<IBaseEntity>(assembly);

        //config entities (config shiits like IEntityTypeConfiguration,.....)
        modelBuilder.RegisterEntityTypeConfiguration(assembly);

    }
}