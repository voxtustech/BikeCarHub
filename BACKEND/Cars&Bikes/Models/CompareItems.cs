using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cars_Bikes.Models
{
    public class CompareItems
    {
        [Key]
        public int Id { get; set; }

        public string Topic { get; set; }

        public string CompareUrl { get; set; }
    }

}
