using AutoMapper;
using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Features.CityOperation.Command;

public record CreateCity(CityVM cityVM) : IRequest<CityVM>;
public class CreateCityHandler : IRequestHandler<CreateCity, CityVM>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public CreateCityHandler(ICityRepository cityRepository, IMapper mapper)
    {
        _cityRepository = cityRepository;
        _mapper = mapper;
    }

    public async Task<CityVM> Handle(CreateCity request, CancellationToken cancellationToken)
    {
        return await _cityRepository.InsertAsync(_mapper.Map<City>(request.cityVM));
    }
}
