using AutoMapper;
using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Features.StudentOperation.Command;

public record CreateStudent(StudentVM studentVM) : IRequest<StudentVM>;

public class CreateStudentHandler : IRequestHandler<CreateStudent, StudentVM>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public CreateStudentHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentVM> Handle(CreateStudent request, CancellationToken cancellationToken)
    {
        return await _studentRepository.InsertAsync(_mapper.Map<Student>(request.studentVM));
    }
}

