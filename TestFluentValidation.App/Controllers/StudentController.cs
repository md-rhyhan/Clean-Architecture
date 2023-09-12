using Microsoft.AspNetCore.Mvc;
using TestFluentValidation.Application.Features.StudentOperation.Command;
using TestFluentValidation.Application.Features.StudentOperation.Query;
using TestFluentValidation.Application.Models.Entities;

namespace TestFluentValidation.App.Controllers;


public class StudentController : BaseController
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<StudentVM>> Get(int id)
    {
        return await HandelQueryAsync(new GetStudentById(id));
    }
    [HttpGet]
    public async Task<ActionResult<List<StudentVM>>> GetList()
    {
        return Ok(await Mediator.Send(new GetStudentList()));
    }
    [HttpPost]
    public async Task<ActionResult<StudentVM>> PostAsync([FromBody]  StudentVM model)
    {
        return await Mediator.Send(new CreateStudent(model));
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult<StudentVM>> PutAsync(int id, [FromBody]StudentVM model)
    {
        return await Mediator.Send(new UpdateStudent(id, model));
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<StudentVM>> DeleteAsync(int id)
    {
        return await Mediator.Send(new DeleteStudent(id));
    }
}
