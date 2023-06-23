using Core.Exceptions;
using DataAccess.Repositoies;
using DataAccess.Repositoies.StudentRepository;
using Domain.Entities;
using Infrastructure.Configurations.Commands;

namespace Application.Commands.StudentCommands.DeleteStudent
{
    public class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand, DeleteStudentResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IUnitOfWork unitOfWork, IStudentRepository studentResultRepository)
        {
          
            _unitOfWork = unitOfWork;
            _studentRepository = studentResultRepository;
        }

        public async Task<DeleteStudentResponse> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            Student? data = await _studentRepository.GetFirstAsync(c => c.Id == command.Request.Id);
            if (data == null) throw new RecordNotFoundException();

            _studentRepository.Delete(data);
            await _unitOfWork.SaveChangesAsync();
            return new DeleteStudentResponse();
        }
    }
}
