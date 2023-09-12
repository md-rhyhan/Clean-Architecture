using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.CountryOperation.Query;

public record GetCountryList() : IRequest<IEnumerable<CountryVM>>;
public class GetCountryListHandler : IRequestHandler<GetCountryList, IEnumerable<CountryVM>>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountryListHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<IEnumerable<CountryVM>> Handle(GetCountryList request, CancellationToken cancellationToken)
    {
        return await _countryRepository.GetAllAsync();
    }
}
