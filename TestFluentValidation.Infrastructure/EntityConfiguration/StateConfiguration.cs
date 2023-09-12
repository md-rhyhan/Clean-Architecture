using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Infrastructure.EntityConfiguration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("States");
        builder.HasKey(x => x.Id);
        builder.HasOne(x=>x.Country).WithMany(x => x.States).HasForeignKey(x => x.CountryId);
        builder.HasData( new State 
        {
            Id = 1,
            Name = "Dhk",
            CountryId = 1,

            CreatedDate = DateTimeOffset.UtcNow,
            CreatedBy = 1,
            IsDeleted = false,

        });

    }
}
