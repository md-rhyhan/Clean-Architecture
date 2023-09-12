using Newtonsoft.Json;

namespace TestFluentValidation.Frontend.Models.ViewModel;

public class State
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}
