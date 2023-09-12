using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.CityOperation.Query;

public record GetCityList() : IRequest<IEnumerable<CityVM>>;

public class GetCityListHandler : IRequestHandler<GetCityList, IEnumerable<CityVM>>
{
    private readonly ICityRepository _cityRepository;

    public GetCityListHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<IEnumerable<CityVM>> Handle(GetCityList request, CancellationToken cancellationToken)
    {
        return await _cityRepository.GetAllAsync(x=>x.State);
    }
}
