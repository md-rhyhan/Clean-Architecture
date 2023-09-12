using System.ComponentModel.DataAnnotations;
using TestFluentValidation.Domain.Base;

namespace TestFluentValidation.Domain.Entities;

public class Student : BaseEntity ,IEntity
{
    [Display(Name = "Student Name")]
    public string StudentName { get; set; } = string.Empty;

    [Display(Name = "Student Email")]
    public string StudentEmail { get; set; } = string.Empty;

    [Display(Name = "Student Number")]
    public string StudentPhone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    [Display(Name = "DOB")]
    public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.UtcNow;

    public string Gender { get; set; }  =string.Empty;
    public Boolean Ssc { get; set; }
    public Boolean Hsc { get; set; }
    public Boolean Bsc { get; set; }
    public bool Msc { get; set; }
    public string? Picture { get; set; }

    
    [Display(Name = "Country")]
    public int CountryId { get; set; }

    [Display(Name = "State")]
    public int StateId { get; set; }

    [Display(Name = "City")]
    public int CityId { get; set; }

    public Country? Country { get; set; }
    public State? State { get; set; }
    public City? City { get; set; }
}
