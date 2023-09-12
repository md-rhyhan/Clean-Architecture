using AutoMapper;
using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Features.CountryOperation.Command;

public record UpdateCountry (int id, CountryVM countryVM) : IRequest<CountryVM>;

public class UpdateCountryHandleer : IRequestHandler<UpdateCountry, CountryVM>
{
    public readonly ICountryRepository _countryRepository;
    public readonly IMapper _mapper;

    public UpdateCountryHandleer(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<CountryVM> Handle(UpdateCountry request, CancellationToken cancellationToken)
    {
        return await _countryRepository.UpdateAsync(request.id, _mapper.Map<Country>(request.countryVM));
    }
}
