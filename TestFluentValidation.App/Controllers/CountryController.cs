using Microsoft.AspNetCore.Mvc;
using TestFluentValidation.Application.Features.CountryOperation.Command;
using TestFluentValidation.Application.Features.CountryOperation.Query;
using TestFluentValidation.Application.Models.Entities;

namespace TestFluentValidation.App.Controllers;

public class CountryController : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CountryVM>> Get(int id)
    {
        return await HandelQueryAsync(new GetCountryById(id));
    }
    [HttpGet]
    public async Task<ActionResult<List<CountryVM>>> GetList()
    {
        return Ok(await Mediator.Send(new GetCountryList()));
    }
    [HttpPost]
    public async Task<ActionResult<CountryVM>> PostAsync(CountryVM model)
    {
        return await Mediator.Send(new CreateCountry(model));
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<CountryVM>> PutAsync(int id, CountryVM model)
    {
        return await Mediator.Send(new UpdateCountry(id, model));
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CountryVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteCountry(id));
    }
}





