using AutoMapper;
using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Features.CityOperation.Command;

public record UpdateCity(int id, CityVM cityVM) : IRequest<CityVM>;
public class UpdateCityHandler : IRequestHandler<UpdateCity, CityVM>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public UpdateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityVM> Handle(UpdateCity request, CancellationToken cancellationToken)
    {
        return await _cityRepository.UpdateAsync(request.id, _mapper.Map<City>(request.cityVM));
    }
}
