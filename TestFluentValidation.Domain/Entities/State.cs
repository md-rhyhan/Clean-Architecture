using System.ComponentModel.DataAnnotations;
using TestFluentValidation.Domain.Base;

namespace TestFluentValidation.Domain.Entities;

public class State : BaseEntity, IEntity
{
    public string Name { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<City> Citys { get; set; } = new HashSet<City>();
    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
}
