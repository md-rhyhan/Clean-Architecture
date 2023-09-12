using MediatR;
using TestFluentValidation.Application.Common;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.StudentOperation.Query;

public record GetStudentById(int id): IRequest<QueryResult<StudentVM>>;
public class GetStudentByIdHandler : IRequestHandler<GetStudentById, QueryResult<StudentVM>>
{
    public readonly IStudentRepository _StudentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository)
    {
        _StudentRepository = studentRepository;
    }

    public async Task<QueryResult<StudentVM>> Handle(GetStudentById request, CancellationToken cancellationToken)
    {
        var data = await _StudentRepository.GetById(request.id);
        if (data == null)
        {
            return new QueryResult<StudentVM>(null, QueryResultTypeEnum.NotFound);
        }
        return new QueryResult<StudentVM>(data, QueryResultTypeEnum.Success);
    }
}
