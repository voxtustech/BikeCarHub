using Microsoft.AspNetCore.Identity;

namespace Cars_Bikes.Models
{
    //public class ApplicationUser : IdentityUser
    public class ApplicationUser : IdentityUser<int>
    {
        public string? FullName { get; set; }
    }
}