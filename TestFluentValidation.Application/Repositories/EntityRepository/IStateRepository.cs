using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.Base;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Repositories.EntityRepository;

public interface IStateRepository : IBaseRepository<State,StateVM,int>
{
}
