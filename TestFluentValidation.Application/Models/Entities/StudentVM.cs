using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TestFluentValidation.Application.Models.Entities;

public class StudentVM : IEntityVM
{
    public int Id { get ; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentEmail { get; set; } = string.Empty;
    public string StudentPhone { get; set; }= string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.UtcNow;

    public string Gender { get; set; } = string.Empty;
    public Boolean Ssc { get; set; }
    public Boolean Hsc { get; set; }
    public Boolean Bsc { get; set; }
    public bool Msc { get; set; }
    public string Picture { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public CountryVM? Country { get; set; }
    public StateVM? State { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public CityVM? City { get; set; }

}
