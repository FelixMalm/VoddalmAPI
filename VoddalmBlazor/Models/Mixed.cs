namespace VoddalmBlazor.Models
{

    public class Rootobject
    {
        public Housing[] Housings { get; set; }
    }

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
        public List<string> Images { get; set; }
        public int categoryId { get; set; }
        public int brokerId { get; set; }
        public int municipalityId { get; set; }
        public Broker broker { get; set; }
        public Municipality municipality { get; set; }
        public Category category { get; set; }
    }

    public class Broker
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string imageUrl { get; set; }
        public Agency agency { get; set; }
        
    }

    public class Agency
    {
        public int id { get; set; }
        public string name { get; set; }
        public string presentation { get; set; }
        public string logoUrl { get; set; }
        public Broker1[] brokers { get; set; }
    }
    public class Agency1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string presentation { get; set; }
        public string logoUrl { get; set; }
        public Broker[] brokers { get; set; }
    }

    public class Broker1
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string imageUrl { get; set; }
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
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        
    }
}
