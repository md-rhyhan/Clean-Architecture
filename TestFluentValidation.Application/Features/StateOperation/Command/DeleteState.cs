using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.StateOperation.Command;

public record DeleteState(int id) : IRequest<StateVM>;
public class DeleteStateHandler : IRequestHandler<DeleteState, StateVM>
{
    private readonly IStateRepository _stateRepository;

    public DeleteStateHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<StateVM> Handle(DeleteState request, CancellationToken cancellationToken)

    {
        return await _stateRepository.DeleteAsync(request.id); 
    }
}
