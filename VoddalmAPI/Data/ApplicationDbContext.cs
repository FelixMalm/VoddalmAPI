﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Housing> Housing { get; set; }
        public DbSet<Agency> Agency { get; set; }
        public DbSet<Broker> Broker { get; set; }
        public DbSet<Municipality> Municipality { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
