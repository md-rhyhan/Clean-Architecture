using AutoMapper;
using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.CountryOperation.Command;

public record DeleteCountry(int id) : IRequest<CountryVM>;

public class DeleteCountryHandler : IRequestHandler<DeleteCountry, CountryVM>
{
    private readonly ICountryRepository _countryRepository;

    public DeleteCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<CountryVM> Handle(DeleteCountry request, CancellationToken cancellationToken)
    {
        return await _countryRepository.DeleteAsync(request.id);
    }
}

