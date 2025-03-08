using System.ComponentModel.DataAnnotations;

namespace AutomaticInfotch_Assignment.Models
{
    public class Vendor
    {
        [Key]
        public string Code { get; set; } // Auto-generated
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        


        [Required(ErrorMessage = "Contact Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [Phone(ErrorMessage = "Invalid Contact Number format.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Contact Number should be 10  digits.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Valid Till Date is required.")]
        [DataType(DataType.Date)]
        public DateTime ValidTillDate { get; set; } = DateTime.Now;



        public bool IsActive { get; set; } = true; // Default to true
    }
}
