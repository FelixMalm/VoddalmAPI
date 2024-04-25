﻿using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Data.Interfaces
{
    public interface IHousing
    {
        Task<IEnumerable<Housing>> GetHousingsAsync();
        Task<Housing> GetHousingByIdAsync(int id);
        Task AddHousingAsync(Housing housing);
        Task UpdateHousingAsync(Housing housing);
        Task DeleteHousingAsync(Housing housing);
    }
}
