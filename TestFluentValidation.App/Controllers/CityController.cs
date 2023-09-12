using Microsoft.AspNetCore.Mvc;
using TestFluentValidation.Application.Features.CityOperation.Command;
using TestFluentValidation.Application.Features.CityOperation.Query;
using TestFluentValidation.Application.Models.Entities;

namespace TestFluentValidation.App.Controllers;


public class CityController : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CityVM>> Get(int id)
    {
        return await HandelQueryAsync(new GetCityById(id));
    }
    [HttpGet]
    public async Task<ActionResult<List<CityVM>>> GetList()
    {
        return Ok(await Mediator.Send(new GetCityList()));
    }
    [HttpPost]
    public async Task<ActionResult<CityVM>> PostAsync(CityVM model)
    {
        return await Mediator.Send(new CreateCity(model));
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<CityVM>> PutAsync(int id, CityVM model)
    {
        return await Mediator.Send(new UpdateCity(id, model));
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CityVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteCity(id));
    }
}
