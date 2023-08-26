using System.ComponentModel.DataAnnotations;

namespace MobilePhoneStore.Models
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Country { get; set; }

      
    }
}
