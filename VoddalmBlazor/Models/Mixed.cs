using System.Collections.Generic;

namespace VoddalmBlazor.Models // Author Kim Jonsson o Felix Malm
{


    public class Housing
    {
        public int id { get; set; }
        public string address { get; set; }
        public int initialPrice { get; set; }
        public int livingArea { get; set; }
        public int additionalArea { get; set; }
        public int plotArea { get; set; }
        public string description { get; set; }
        public int numberOfRooms { get; set; }
        public int monthlyFee { get; set; }
        public int annualOperatingCost { get; set; }
        public int yearBuilt { get; set; }
        public List<string> images { get; set; }
        public int categoryId { get; set; }
        public string brokerId { get; set; }
        public int municipalityId { get; set; }
        public bool IsActive { get; set; } = true;
        public Broker broker { get; set; }
        public Municipality municipality { get; set; }
        public Category category { get; set; }
    }

    public class Broker
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string imageUrl { get; set; }
        public Agencies agency { get; set; }
        public string id { get; set; }
        public string userName { get; set; }
        public string normalizedUserName { get; set; }
        public string email { get; set; }
        public string normalizedEmail { get; set; }
        public bool emailConfirmed { get; set; }
        public string passwordHash { get; set; }
        public string securityStamp { get; set; }
        public string concurrencyStamp { get; set; }
        public string phoneNumber { get; set; }
        public bool phoneNumberConfirmed { get; set; }
        public bool twoFactorEnabled { get; set; }
        public bool lockoutEnabled { get; set; }
        public int accessFailedCount { get; set; }
    }

   

    public class Municipality
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public bool Flag { get; set; }
        public string Message { get; set; }
    }

    public class RefreshModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class RegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
