using VoddalmAPI.Data.Models;
using static VoddalmAPI.Data.Models.ServiceResponses;

namespace VoddalmAPI.Data.Interfaces
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount (LoginDTO loginDTO);
    }
}
