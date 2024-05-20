namespace VoddalmAPI.Data.Models
{
    public class ServiceResponses
    {
        //Author Felix
        public record class GeneralResponse(bool Flag, string Message);
        public record class LoginResponse(bool Flag, string Token,  string Message);
    }
}
