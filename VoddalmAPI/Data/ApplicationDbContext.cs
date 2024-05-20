using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Data
{
    // Author Kim o felix
    public class ApplicationDbContext : IdentityDbContext<Broker>
    {

        public DbSet<Housing> Housing { get; set; }
        public DbSet<Agency> Agency { get; set; }
        public DbSet<Broker> Broker { get; set; }
        public DbSet<Municipality> Municipality { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = ApiRoles.User,
                    NormalizedName = ApiRoles.User,
                    Id = "User"
                    
                },
                new IdentityRole
                {
                    Name = ApiRoles.Admin,
                    NormalizedName = ApiRoles.Admin,
                    Id = "Admin"
                    
                }

                );
          
        }
    }
}