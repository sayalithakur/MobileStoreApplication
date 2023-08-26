using System.ComponentModel.DataAnnotations;

namespace MobilePhoneStore.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Role { get; set; }
    }
}
