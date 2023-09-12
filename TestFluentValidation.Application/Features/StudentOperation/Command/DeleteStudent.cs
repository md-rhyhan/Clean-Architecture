using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;

namespace TestFluentValidation.Application.Features.StudentOperation.Command;

public record DeleteStudent(int id) : IRequest<StudentVM>;
public class DeleteStudentHandler : IRequestHandler<DeleteStudent, StudentVM>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentVM> Handle(DeleteStudent request, CancellationToken cancellationToken)
    {
        return await _studentRepository.DeleteAsync(request.id);
    }
}
