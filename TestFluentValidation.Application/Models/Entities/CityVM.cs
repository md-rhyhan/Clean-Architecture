using Newtonsoft.Json;

namespace TestFluentValidation.Application.Models.Entities;

public class CityVM : IEntityVM
{
    public int Id { get ; set ; }
    public string Name { get; set ; }
    public int StateId { get; set; }
    public StateVM? State { get; set; }
}
