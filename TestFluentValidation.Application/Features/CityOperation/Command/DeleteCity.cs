using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.CityOperation.Command;

public record DeleteCity (int id) : IRequest<CityVM>;

public class DeleteCityHandler : IRequestHandler<DeleteCity, CityVM>
{
    private readonly ICityRepository _cityRepository;

    public DeleteCityHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<CityVM> Handle(DeleteCity request, CancellationToken cancellationToken)
    {
        return await _cityRepository.DeleteAsync(request.id);
    }
}
