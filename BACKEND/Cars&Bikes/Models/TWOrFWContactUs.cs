using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Bikes.Models
{
    [Table("TWOrFWContactUs")]
    public class TWOrFWContactUs
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(60)")]
        public string Name { get; set; }
        [Required, NotNull]
        [DisplayName("Phone No.")]
        public string PhoneNo { get; set; }
        [Required]
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
