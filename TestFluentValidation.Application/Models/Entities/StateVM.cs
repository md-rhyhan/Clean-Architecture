using Newtonsoft.Json;

namespace TestFluentValidation.Application.Models.Entities;

public class StateVM : IEntityVM
{
    public int Id { get ; set ; }
    public string Name { get ; set ; } = string.Empty;
    public int CountryId { get; set; }
    public CountryVM? Country { get; set; }
}
