using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestFluentValidation.Application.Features.CountryOperation.Command;
using TestFluentValidation.Application.Features.CountryOperation.Query;
using TestFluentValidation.Application.Features.StateOperation.Command;
using TestFluentValidation.Application.Features.StateOperation.Query;
using TestFluentValidation.Application.Models.Entities;

namespace TestFluentValidation.App.Controllers;


public class StateController : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<StateVM>> Get(int id)
    {
        return await HandelQueryAsync(new GetStateById(id));
    }
    [HttpGet]
    public async Task<ActionResult<List<StateVM>>> GetList()
    {
        return Ok(await Mediator.Send(new GetStateList()));
    }
    [HttpPost]
    public async Task<ActionResult<StateVM>> PostAsync(StateVM model)
    {
        return await Mediator.Send(new CreateState(model));
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<StateVM>> PutAsync(int id, StateVM model)
    {
        return await Mediator.Send(new UpdateState(id, model));
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<StateVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteState(id));
    }
}
