using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.StateOperation.Query;

public record GetStateList() : IRequest<IEnumerable<StateVM>>;

public class GetStateListHandler : IRequestHandler<GetStateList, IEnumerable<StateVM>>
{
    private readonly IStateRepository _stateRepository;

    public GetStateListHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<IEnumerable<StateVM>> Handle(GetStateList request, CancellationToken cancellationToken)
    {
      
        return await _stateRepository.GetAllAsync(x => x.Country);

    }
}
