using Core.Constants;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.StudentCommands.UpdateStudent
{
    public class UpdateStudentRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(StringLengthConstants.LengthLg)]
        public string FullName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public double Average { get; set; } = 0;

    }
}
