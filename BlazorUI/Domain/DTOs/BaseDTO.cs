using System.ComponentModel.DataAnnotations;

namespace UI.Domain.DTOs
{
    public abstract class BaseDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
