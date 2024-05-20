using System.ComponentModel.DataAnnotations;
namespace VoddalmAPI.Data.Models
    //Linus
{
    public class LoginDTO
    {
        //Author Linus o Felix
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
