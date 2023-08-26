using System.ComponentModel.DataAnnotations;

namespace MobilePhoneStore.Models
{
    public class MobilePhone
    {
        [Key]
        public int MobilePhoneID { get; set; }
        public int BrandID { get; set; }
        public string ModelName { get; set; }
       
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
    }
}
