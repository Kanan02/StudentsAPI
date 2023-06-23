using AutoMapper;
using Core.Exceptions;
using DataAccess.Repositoies;
using DataAccess.Repositoies.StudentRepository;
using Domain.Entities;
using Infrastructure.Configurations.Commands;

namespace Application.Commands.StudentCommands.CreateStudent
{
    public class CreateStudentCommandHandler : ICommandHandler<CreateStudentCommand, CreateStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IStudentRepository studentResultRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _studentRepository = studentResultRepository;
        }

        public async Task<CreateStudentResponse> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            Student? data = _mapper.Map<CreateStudentRequest, Student>(command.Request);
            if (data == null) throw new RecordNotFoundException(message: "Provided Student is null");
            
            data.CreatedAt = DateTime.Now;
            data.UpdatedAt = DateTime.Now;
            await _studentRepository.AddAsync(data);
            await _unitOfWork.SaveChangesAsync();

            return new CreateStudentResponse()
            {
                Response = data
            };
        }
    }
}
