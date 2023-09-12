using Newtonsoft.Json;

namespace TestFluentValidation.Frontend.Models.ViewModel;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int StateId { get; set; }
    public State? State { get; set; }
}
