using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace Cars_Bikes.Models
{
    public class TWEVAppFeatures
    {
        [Key]
        public int TWEVAppFeaturesId { get; set; }
        public string? TWName { get; set; }
        public string? Varients { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? ChargingStationLocate { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Geofencing { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? AntiTheftAlarm { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? CallsAndMessaging { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? NavigationAssis { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? LowBatteryAlert { get; set; }
        public int? TwoWheelerId { get; set; }
        [ForeignKey("TwoWheelerId")]
        [ValidateNever]
        public virtual TwoWheeler TwoWheeler { get; set; }
        public int? TWVarientId { get; set; }
        [ForeignKey("TWVarientId")]
        [ValidateNever]
        public virtual TWVarient TWVarients { get; set; }
        public DateTime? CreatedDateTime { get; set; } = DateTime.Now;
    }
}
