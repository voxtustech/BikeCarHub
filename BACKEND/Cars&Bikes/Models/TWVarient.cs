using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Cars_Bikes.Models
{
    public class TWVarient
    {
        [Key]
        public int TWVarientId { get; set; }
        public string? Varients { get; set; }
        public string? TWName { get; set; }
        public int? TwoWheelerId { get; set; }
        [ForeignKey("TwoWheelerId")]
        [ValidateNever]
        public virtual TwoWheeler TwoWheeler { get; set; }
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
    }
}
