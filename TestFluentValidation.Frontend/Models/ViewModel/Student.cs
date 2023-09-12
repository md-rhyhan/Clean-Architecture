using System.ComponentModel.DataAnnotations;

namespace TestFluentValidation.Frontend.Models.ViewModel;

public class Student
{
    public int Id { get; set; }

    [Display(Name = "Student Name")]
    public string StudentName { get; set; } = string.Empty;

    [Display(Name = "Student Email")]
    public string StudentEmail { get; set; }= string.Empty;

    [Display(Name = "Student Number")]
    public string StudentPhone { get; set; }=string.Empty;
    public string Address { get; set; } = string.Empty;

    [Display(Name = "DOB")]
    public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.UtcNow;

    public string Gender { get; set; } = string.Empty;
    public Boolean Ssc { get; set; }
    public Boolean Hsc { get; set; }
    public Boolean Bsc { get; set; }
    public bool Msc { get; set; }
    public string Picture { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public State? State { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
}
