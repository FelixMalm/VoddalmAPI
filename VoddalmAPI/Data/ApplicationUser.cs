using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VoddalmAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
    }
}
