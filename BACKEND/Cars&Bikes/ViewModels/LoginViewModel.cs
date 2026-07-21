//using System;
//namespace Cars_Bikes.ViewModels
//{
//	public class LoginViewModel
//	{
//		public LoginViewModel()
//		{
//		}
//	}
//}

using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;

namespace Cars_Bikes.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        //public string EmailOrPhone { get; set; }
        [Display(Name = "Email or Username")]
        [Required(ErrorMessage = "Email or Username is required.")]
        public string EmailOrPhone { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}