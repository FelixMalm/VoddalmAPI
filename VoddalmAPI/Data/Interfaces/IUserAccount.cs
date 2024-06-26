﻿using VoddalmAPI.Data.Models;
using static VoddalmAPI.Data.Models.ServiceResponses;
//Linus
namespace VoddalmAPI.Data.Interfaces
{
    //Linus
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(UserDTO userDTO);
        Task<LoginResponse> LoginAccount (LoginDTO loginDTO);
    }
}
