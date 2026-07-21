using System.ComponentModel.DataAnnotations;

namespace Cars_Bikes.Models
{
    public class FourWheelerBrand
    {
        [Key]
        public int Id { get; set; }
        public String? FourWheelerBrandName { get; set; }
    }
}
