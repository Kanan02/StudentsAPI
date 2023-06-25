using System.ComponentModel.DataAnnotations;

namespace Domain.Common.Configurations
{
    public class Entity : IEntity
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
