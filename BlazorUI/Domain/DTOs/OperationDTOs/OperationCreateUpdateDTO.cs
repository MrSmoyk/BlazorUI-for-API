using System.ComponentModel.DataAnnotations;

namespace UI.Domain.DTOs.OperationDTOs
{
    public class OperationCreateUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public string TypeName { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than zero!")]
        public int Amount { get; set; }
    }
}
