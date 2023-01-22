using System.ComponentModel.DataAnnotations;

namespace UI.Domain.DTOs.OperationTypeDTOs
{
    public class OperationTypeCreateUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        [Range(typeof(bool), "false", "false", ErrorMessage = "Name must be unique!")]
        public bool IsNameRepeat { get; set; } = false;

        public string? Description { get; set; }

        [Required]
        public bool IsIncome { get; set; }
    }
}
