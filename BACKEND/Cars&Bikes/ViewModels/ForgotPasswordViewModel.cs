using System.ComponentModel.DataAnnotations;

namespace Cars_Bikes.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string EmailOrUsername { get; set; }
    }
}