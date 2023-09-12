using TestFluentValidation.Domain.Base;

namespace TestFluentValidation.Domain.Entities;

public class Country : BaseEntity, IEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<State> States { get; set; } = new HashSet<State>();
    public ICollection<City> Cities { get; set; } = new HashSet<City>();    
    public ICollection<Student> Students { get; set; } = new HashSet<Student>();

}
