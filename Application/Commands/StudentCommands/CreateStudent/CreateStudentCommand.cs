using Infrastructure.Configurations.Commands;

namespace Application.Commands.StudentCommands.CreateStudent
{
    public class CreateStudentCommand : CommandBase<CreateStudentResponse>
    {
        public CreateStudentCommand(CreateStudentRequest request)
        {
            Request = request;
        }

        public CreateStudentRequest Request { get; set; }
    }
}
