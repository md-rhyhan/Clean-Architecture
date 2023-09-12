using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.Base;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Repositories.EntityRepository
{
    public interface IStudentRepository : IBaseRepository<Student ,StudentVM, int>
    {
    }
}
