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

        public string ImageUrl { get; set; } = "https://t3.ftcdn.net/jpg/04/60/01/36/360_F_460013622_6xF8uN6ubMvLx0tAJECBHfKPoNOR5cRa.jpg";
        [Required]
        public Agency Agency { get; set; } 
    }
}
