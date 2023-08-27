using Microsoft.AspNetCore.Identity;

namespace tp3JordanCoutureLafranchise.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string NickName { get; set; }
    }
}
