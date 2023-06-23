using AutoMapper;
using Core.Exceptions;
using DataAccess.Repositoies;
using DataAccess.Repositoies.StudentRepository;
using Domain.Entities;
using Infrastructure.Configurations.Commands;

namespace Application.Commands.StudentCommands.UpdateStudent
{
    public class UpdateStudentCommandHandler : ICommandHandler<UpdateStudentCommand, UpdateStudentResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IStudentRepository studentResultRepository)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = studentResultRepository;
        }

        public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
        {
            Student? data = _studentRepository.FindBy(x => x.Id == command.Request.Id).FirstOrDefault();
            if (data == null) throw new RecordNotFoundException("Student not found while update");

            data.FullName = command.Request.FullName;
            data.Average = command.Request.Average;
            data.DateOfBirth = command.Request.DateOfBirth;
            data.UpdatedAt=DateTime.Now;

            _studentRepository.Update(data);
            await _unitOfWork.SaveChangesAsync();
            return new UpdateStudentResponse()
            {
                Response = data
            };
        }
    }
}
