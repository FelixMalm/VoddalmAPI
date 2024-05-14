using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VoddalmAPI.Data.Models
{
    public class Broker : IdentityUser
    {
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
       
        public string ImageUrl { get; set; }
        [Required]
        
        public Agency Agency { get; set; }
        
    }
}
