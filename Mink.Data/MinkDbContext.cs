using Microsoft.EntityFrameworkCore;
using Mink.Data.Configurations;
using Mink.Domain.Models.Entities;

namespace Mink.Data
{
    public class MinkDbContext : DbContext
    {
        public DbSet<MinifiedUri> Uris { get; set; }
        // public DbSet<> Clicks { get; set; }

        public MinkDbContext(DbContextOptions<MinkDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MinifiedUriConfiguration());
        }
    }
}