using System.ComponentModel.DataAnnotations;

namespace Cars_Bikes.Models
{
    public class LoginModel
    {
        [Key]
        public int LoginId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
