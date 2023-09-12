using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TestFluentValidation.Infrastructure.AppContext;

public class TestFluentValidationDbContext : DbContext
{
    public TestFluentValidationDbContext(DbContextOptions<TestFluentValidationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys())
            .ToList().ForEach(x => x.DeleteBehavior = DeleteBehavior.Restrict);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
