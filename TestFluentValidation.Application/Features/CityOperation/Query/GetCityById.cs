using MediatR;
using TestFluentValidation.Application.Common;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.CityOperation.Query;

public record GetCityById(int Id) : IRequest<QueryResult<CityVM>>;
public class GetCityByIdHandler : IRequestHandler<GetCityById, QueryResult<CityVM>>
{
    private readonly ICityRepository _cityRepository;

    public GetCityByIdHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<QueryResult<CityVM>> Handle(GetCityById request, CancellationToken cancellationToken)
    {
        var data = await _cityRepository.GetById(request.Id);
        if (data == null)
        {
            return new QueryResult<CityVM>(null, QueryResultTypeEnum.NotFound);
        }
        return new QueryResult<CityVM>(data, QueryResultTypeEnum.Success);
    }
}
