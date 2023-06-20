using Core.Constants;
using Domain.Common.Configurations;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Student: Entity
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [StringLength(StringLengthConstants.LengthLg)]
        public string FullName { get; set; } = "";
        [Required]
        public DateTime DateOfBirth { get; set; }

        public double Average { get; set; } = 0;



        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
