using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Data
{
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
                    //Lägg till Id efter migration
                },
                new IdentityRole
                {
                    Name = ApiRoles.Admin,
                    NormalizedName = ApiRoles.Admin,
                    Id = "Admin"
                    //Lägg till Id efter migration
                }

                );
            //var hasher = new PasswordHasher<Broker>();
            //builder.Entity<Broker>().HasData(
            //    new Broker
            //    {
            //        Id = "e2e1bd99-2aec-4519-bebf-dcc9c66ce64a",
            //        Email = "admin@demoapi.com",
            //        NormalizedEmail = "ADMIN@DEMOAPI.COM",
            //        UserName = "admin@demoapi.com",
            //        NormalizedUserName = "ADMIN@DEMOAPI.COM",
            //        FirstName = "System",
            //        LastName = "Admin",
            //        PasswordHash = hasher.HashPassword(null, "Test1234!"),
            //        EmailConfirmed = true
            //    },
            //    new Broker
            //    {
            //        Id = "00cf8131-3484-4bb2-b079-2831ef714d4c",
            //        Email = "user@demoapi.com",
            //        NormalizedEmail = "USER@DEMOAPI.COM",
            //        UserName = "user@demoapi.com",
            //        NormalizedUserName = "USER@DEMOAPI.COM",
            //        FirstName = "System",
            //        LastName = "User",
            //        PasswordHash = hasher.HashPassword(null, "Test1234!"),
            //        EmailConfirmed = true
            //    }
            //);
        }
    }
}