using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.StudentCommands.CreateStudent
{
    public class CreateStudentRequest
    {
        [Required]
        [StringLength(StringLengthConstants.LengthLg)]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public double Average { get; set; } = 0;

    }
}
