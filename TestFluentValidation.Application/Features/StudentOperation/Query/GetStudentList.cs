using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.StudentOperation.Query;

public record GetStudentList () : IRequest<IEnumerable<StudentVM>>;

public class GetStudentListHandler : IRequestHandler<GetStudentList, IEnumerable<StudentVM>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<IEnumerable<StudentVM>> Handle(GetStudentList request, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetAllAsync(x=>x.Country,x=>x.State,x=>x.City);
    }
}
