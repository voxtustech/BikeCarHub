using System.ComponentModel.DataAnnotations;

namespace Cars_Bikes.Models
{
    public class NewsLetter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
