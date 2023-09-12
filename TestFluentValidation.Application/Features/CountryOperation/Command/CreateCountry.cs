using AutoMapper;
using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Features.CountryOperation.Command;

public record CreateCountry(CountryVM countryVM) : IRequest<CountryVM>;

public class CreateCountryHandler : IRequestHandler<CreateCountry, CountryVM>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public CreateCountryHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CountryVM> Handle(CreateCountry request, CancellationToken cancellationToken)
    {
        return await _countryRepository.InsertAsync(_mapper.Map<Country>(request.countryVM));
    }
}
