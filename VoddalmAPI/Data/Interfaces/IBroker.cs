using VoddalmAPI.Data.Models;
// Linus Anderstedt
namespace VoddalmAPI.Data.Interfaces
{
	public interface IBroker
    {
        Task<IEnumerable<Broker>> GetBrokersAsync();
        Task<Broker> GetBrokerByIdAsync(string id);
        Task AddBrokerAsync(Broker broker);
        Task UpdateBrokerAsync(Broker broker);
        Task DeleteBrokerAsync(Broker broker);
    }
}
