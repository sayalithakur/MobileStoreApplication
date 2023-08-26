using System.ComponentModel.DataAnnotations;

namespace MobilePhoneStore.Models
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        public int MobilePhoneID { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public MobilePhone MobilePhone { get; set; }
        public List<Discount> Discounts { get; set; }
    }
}
