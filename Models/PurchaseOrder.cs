namespace AutomaticInfotch_Assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PurchaseOrder
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }= DateTime.Now;

        [Required]
        public string Vendor { get; set; }

        [Required]
        public string Notes { get; set; }

        [Display(Name = "Order Value")]
        [DataType(DataType.Currency)]
        public decimal OrderValue { get; set; }


        [NotMapped] //ignore the vendors field from being created in the database
        public List<Vendor> vendors { get; set; }   

        // Line Items represented as a list of dictionaries or nested class
        public List<LineItem> LineItems { get; set; } = new List<LineItem>();

        public class LineItem
        {

            [Key]
            public int LineId { get; set; }
            [Required]
            public string MaterialCode { get; set; }

            [Display(Name = "Short Text")]
            public string ShortText { get; set; }

            [Required]
            public string UOM { get; set; }  // Unit of Measure

            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
            public int Quantity { get; set; }

            [Required]
            [DataType(DataType.Currency)]
            public decimal Rate { get; set; }

            [DataType(DataType.Currency)]
            public decimal Amount => Quantity * Rate;

            [DataType(DataType.Date)]
            [Display(Name = "Expected Date")]
            public DateTime ExpectedDate { get; set; }= DateTime.Now;

            // Foreign key reference
          /*  public int PurchaseOrderOrderId { get; set; }
            public PurchaseOrder PurchaseOrder { get; set; }*/
        }
    }

}
