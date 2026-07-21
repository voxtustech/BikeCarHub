using Cars_Bikes.Models;

namespace Cars_Bikes.ViewModels
{
    public class TwoWheelerFullDetailsViewModel
    {
        public TwoWheeler? TwoWheeler { get; set; }

        public TWSpec? TWSpec { get; set; }
        public TWMotorAndBattery? TWMotorAndBattery { get; set; }
        public TWFeatures? TWFeatures { get; set; }
        public TWMileageAndPerformance? TWMileageAndPerformance { get; set; }
        public TWImageColorPrice? TWImageColorPrice { get; set; }
        public TWChassisAndSuspension? TWChassisAndSuspension { get; set; }
        public TWElectricals? TWElectricals { get; set; }
        public TWDimensionsAndCapacity? TWDimensionsAndCapacity { get; set; }
        public TWCharging? TWCharging { get; set; }
    }
}