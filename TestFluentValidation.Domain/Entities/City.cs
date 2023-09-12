using System.ComponentModel.DataAnnotations;
using TestFluentValidation.Domain.Base;

namespace TestFluentValidation.Domain.Entities;

public class City : BaseEntity, IEntity
{
    public string Name { get; set; } = string.Empty;    

    [Display(Name = "State")]
    public int StateId { get; set; }
    public State State { get; set; }
    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
}
