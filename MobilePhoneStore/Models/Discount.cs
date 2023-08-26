using System.ComponentModel.DataAnnotations;

namespace MobilePhoneStore.Models
{
    public class Discount
    {
        [Key]
        public int DiscountID { get; set; }
        public int SaleID { get; set; }
        public decimal DiscountAmount { get; set; }
        public string DiscountReason { get; set; }

        public Sale Sale { get; set; }
    }
}
