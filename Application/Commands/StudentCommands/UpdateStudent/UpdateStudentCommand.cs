using Infrastructure.Configurations.Commands;

namespace Application.Commands.StudentCommands.UpdateStudent
{
    public class UpdateStudentCommand : CommandBase<UpdateStudentResponse>
    {
        public UpdateStudentCommand(UpdateStudentRequest request)
        {
            Request = request;
        }

        public UpdateStudentRequest Request { get; set; }
    }
}
