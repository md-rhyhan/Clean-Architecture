using MediatR;
using TestFluentValidation.Application.Common;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.CountryOperation.Query;

public record GetCountryById(int id) : IRequest<QueryResult<CountryVM>>;

public class GetCountryByIdHandler : IRequestHandler<GetCountryById, QueryResult<CountryVM>>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountryByIdHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<QueryResult<CountryVM>> Handle(GetCountryById request, CancellationToken cancellationToken)
    {
        var result = await _countryRepository.GetById(request.id);
        if (result == null)
        {
            return new QueryResult<CountryVM>(null,QueryResultTypeEnum.NotFound);
        }
        return new QueryResult<CountryVM>(result,QueryResultTypeEnum.Success);
    }
}
