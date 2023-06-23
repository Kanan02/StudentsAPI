using Infrastructure.Configurations.Commands;

namespace Application.Commands.StudentCommands.DeleteStudent
{
    public class DeleteStudentCommand : CommandBase<DeleteStudentResponse>
    {
        public DeleteStudentCommand(DeleteStudentRequest request)
        {
            Request = request;
        }

        public DeleteStudentRequest Request { get; set; }
    }
}
