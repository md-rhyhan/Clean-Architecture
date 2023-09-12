using AutoMapper;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.Base;
using TestFluentValidation.Domain.Entities;
using TestFluentValidation.Infrastructure.AppContext;

namespace TestFluentValidation.Application.Repositories.EntityRepository;

public class CountryRepository : BaseRepository<Country, CountryVM, int>, ICountryRepository
{
    public CountryRepository(IMapper mapper, TestFluentValidationDbContext dbContext) : base(mapper, dbContext)
    {
    }
}
