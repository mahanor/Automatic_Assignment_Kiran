using System.ComponentModel.DataAnnotations;

namespace AutomaticInfotch_Assignment.Models
{
    public class Material
    {
        [Key]
        [Required]
        public string Code { get; set; }

        [Required(ErrorMessage = "Short Text is required.")]
        [StringLength(100, ErrorMessage = "Short Text cannot exceed 100 characters.")]
        public string ShortText { get; set; }

        [StringLength(500, ErrorMessage = "Long Text cannot exceed 500 characters.")]
        public string LongText { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(10, ErrorMessage = "Unit cannot exceed 10 characters.")]
        public string Unit { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Reorder Level must be a positive value.")]
        public decimal ReorderLevel { get; set; }

        [Required(ErrorMessage = "Minimum Order Quantity is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Minimum Order Quantity must be at least 1.")]
        public int MinOrderQuantity { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
