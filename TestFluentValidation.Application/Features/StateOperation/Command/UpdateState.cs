using AutoMapper;
using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Features.StateOperation.Command;

public record UpdateState(int id, StateVM stateVM) : IRequest<StateVM>;

public class UpdateStateHandler : IRequestHandler<UpdateState, StateVM>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public UpdateStateHandler(IStateRepository stateRepository, IMapper mapper)
    {
        _stateRepository = stateRepository;
        _mapper = mapper;
    }

    public async Task<StateVM> Handle(UpdateState request, CancellationToken cancellationToken)
    {
        return await _stateRepository.UpdateAsync(request.id,_mapper.Map<State>(request.stateVM));
    }
}
