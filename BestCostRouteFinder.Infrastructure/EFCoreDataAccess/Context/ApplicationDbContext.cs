using CheapestRouteFinder.Domain.AggregateModels.Route;
using CheapestRouteFinder.Infrastructure.EFCoreDataAccess.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CheapestRouteFinder.Infrastructure.EFCoreDataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;User Id=sa;Password=123@Password;Database=RouteFinder");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoutesConfiguration());
        }

        public DbSet<Route> Route { get; set; }
    }
}
