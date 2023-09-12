using AutoMapper;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.Base;
using TestFluentValidation.Domain.Entities;
using TestFluentValidation.Infrastructure.AppContext;

namespace TestFluentValidation.Application.Repositories.EntityRepository;

public class StudentRepository : BaseRepository<Student, StudentVM, int>, IStudentRepository
{
    public StudentRepository(IMapper mapper, TestFluentValidationDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
