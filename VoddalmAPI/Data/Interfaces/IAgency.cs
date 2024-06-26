﻿using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Data.Interfaces
{
    public interface IAgency //Author Felix
    {
        Task<IEnumerable<Agency>> GetAgencyAsync();
        Task<Agency> GetAgencyByIdAsync(int id);
        Task AddAgencyAsync(Agency agency);
        Task UpdateAgencyAsync(Agency agency);
        Task DeleteAgencyAsync(int id);
        Task<Agency> GetAgencyByNameAsync(string name);
        Task<Agency> GetAgencyWithIdAsync(int id);
    }
}