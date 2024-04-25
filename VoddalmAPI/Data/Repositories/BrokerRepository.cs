using VoddalmAPI.Data.Models;
using VoddalmAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

// Linus Anderstedt
namespace VoddalmAPI.Data.Repositories
{
	public class BrokerRepository : IBroker
	{
		private readonly ApplicationDbContext _context;

		public BrokerRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Broker>> GetBrokersAsync()
		{
			return await _context.Broker.Include(s => s.Agency).ToListAsync();
		}

        public async Task<Broker> GetBrokerByIdAsync(int id)
        {
            var broker = await _context.Broker.FindAsync(id);

            if (broker != null)
            {
                await _context.Entry(broker).Reference(s => s.Agency).LoadAsync();
            }

            return broker;
        }

        public async Task AddBrokerAsync(Broker broker)
        {
            _context.Broker.Add(broker);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBrokerAsync(Broker broker)
        {
            _context.Entry(broker).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBrokerAsync(Broker broker)
        {
            _context.Broker.Remove(broker);
            await _context.SaveChangesAsync();
        }
    }
}
