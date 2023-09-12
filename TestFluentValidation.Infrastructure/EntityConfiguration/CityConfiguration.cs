using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Infrastructure.EntityConfiguration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Citys");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.State).WithMany(x => x.Citys).HasForeignKey(x => x.StateId);
        builder.HasData(new City
        {
            Id = 1,
            Name = "state",
            StateId = 1,

            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDeleted = false,

        });
    }
}
