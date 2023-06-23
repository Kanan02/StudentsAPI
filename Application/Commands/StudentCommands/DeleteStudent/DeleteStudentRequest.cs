using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.StudentCommands.DeleteStudent
{
    public class DeleteStudentRequest
    {
        [Required]
        public string Id { get; set; }

    }
}
