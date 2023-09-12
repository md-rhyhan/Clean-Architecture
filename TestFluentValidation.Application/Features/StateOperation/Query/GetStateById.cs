using MediatR;
using TestFluentValidation.Application.Common;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.StateOperation.Query;

public record GetStateById(int id) : IRequest<QueryResult<StateVM>>;

public class GetStateByIdHandler : IRequestHandler<GetStateById, QueryResult<StateVM>>
{
    public readonly IStateRepository _stateRepository;

    public GetStateByIdHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<QueryResult<StateVM>> Handle(GetStateById request, CancellationToken cancellationToken)
    {
        var date = await _stateRepository.GetById(request.id);
        if (date == null) 
        {
            return new QueryResult<StateVM>(null, QueryResultTypeEnum.NotFound);
        }
        return new QueryResult<StateVM>(date, QueryResultTypeEnum.Success);

    }
}
