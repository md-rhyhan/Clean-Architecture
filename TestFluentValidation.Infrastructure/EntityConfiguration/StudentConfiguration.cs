using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Infrastructure.EntityConfiguration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(t => t.Id);
        builder.HasOne(t => t.Country).WithMany(e => e.Students).HasForeignKey(t => t.CountryId);
        builder.HasOne(e => e.State).WithMany(e => e.Students).HasForeignKey(e => e.StateId);
        builder.HasOne(e => e.City).WithMany(c => c.Students).HasForeignKey(c => c.CityId);
        builder.HasData(  new Student
        {
            Id = 1,
            StudentName = "Rhyhan",
            StudentEmail = "rhyhan@gmail.com",
            StudentPhone = "017xxxxxxxx",
            Address = "DHk-1200",
            DateOfBirth= DateTimeOffset.UtcNow,
            Gender= "Male",
            Picture = "",
            Ssc = true,
            Hsc = true,
            Bsc = true,
            Msc = false,
            CountryId = 1,
            StateId = 1,
            CityId = 1
        } );
    }
}
