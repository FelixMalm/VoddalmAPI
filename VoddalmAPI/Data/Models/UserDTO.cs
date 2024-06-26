﻿using System.ComponentModel.DataAnnotations;
namespace VoddalmAPI.Data.Models
    //Linus
{
    //Author Linus
    public class UserDTO
    {
        public string? Id { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;

        public int? AgencyId { get; set; }
    }
}