using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MotorcycleManager.Domain.Models;

namespace MotorcycleManager.Infrastructure.Context
{
    public class MotorcycleManagerContext : DbContext
    {
        public IConfiguration configuration { get; }

        public MotorcycleManagerContext(DbContextOptions<MotorcycleManagerContext> options) : base(options) { }

        public DbSet<MotorcycleEntity> Motorcycles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotorcycleEntity>().ToTable("Motorcycle");
            modelBuilder.Entity<MotorcycleCrossEntity>().ToTable("MotorcycleCross");
            modelBuilder.Entity<MotorcycleSportsEntity>().ToTable("MotorcycleSports");
            modelBuilder.Entity<MotorcycleTourismEntity>().ToTable("MotorcycleTourism");
        }
    }
}
