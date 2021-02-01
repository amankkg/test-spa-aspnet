using Microsoft.AspNetCore.Identity;

namespace CustomIdentityData
{
    public class User : IdentityUser<int>
    {
        public int Height { get; set; }
    }
}
