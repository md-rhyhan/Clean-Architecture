using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.Base;
using TestFluentValidation.Domain.Entities;
using TestFluentValidation.Infrastructure.AppContext;

namespace TestFluentValidation.Application.Repositories.EntityRepository;

public class StateRepository : BaseRepository<State, StateVM, int>, IStateRepository
{
    public StateRepository(IMapper mapper, TestFluentValidationDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
