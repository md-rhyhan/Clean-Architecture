using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Infrastructure.EntityConfiguration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {

        builder.ToTable("Country");
        builder.HasKey(x=>x.Id);
        builder.HasData(new Country
        {
            Id = 1,
            Name = "Bd",

            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDeleted = false,

        }) ;
    }
}
