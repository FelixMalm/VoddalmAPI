using Microsoft.EntityFrameworkCore;
using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Housing> Housing { get; set; }
        public DbSet<Agency> Agency { get; set; }
        public DbSet<Broker> Broker { get; set; }
        public DbSet<Municipality> Municipality { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       




    }
}
