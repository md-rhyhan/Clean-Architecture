using AutoMapper;
using MediatR;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Application.Repositories.EntityRepository;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Features.StudentOperation.Command;

public record UpdateStudent (int id, StudentVM studentVM) : IRequest<StudentVM>;
public class UpdateStudentHandler : IRequestHandler<UpdateStudent, StudentVM>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public UpdateStudentHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentVM> Handle(UpdateStudent request, CancellationToken cancellationToken)
    {
        return await _studentRepository.UpdateAsync(request.id, _mapper.Map<Student>(request.studentVM));
    }
}
