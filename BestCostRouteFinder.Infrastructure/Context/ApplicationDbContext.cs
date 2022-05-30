using BestCostRouteFinder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BestCostRouteFinder.Infrastructure.Context
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
            modelBuilder.Entity<Place>().HasData(
                new Place
                {
                    Id = 1,
                    Name = "GRU"
                },
                new Place
                {
                    Id = 2,
                    Name = "BRC"
                },
                new Place
                {
                    Id = 3,
                    Name = "SCL"
                },
                new Place
                {
                    Id = 4,
                    Name = "CDG"
                },
                new Place
                {
                    Id = 5,
                    Name = "ORL"
                }
            );

            modelBuilder.Entity<Route>().HasData(
                new Route
                {
                    Id = 1,
                    Origin = "GRU",
                    Destiny = "BRC",
                    Cost = 10
                },
                new Route
                {
                    Id = 2,
                    Origin = "BRC",
                    Destiny = "SCL",
                    Cost = 5
                },
                new Route
                {
                    Id = 3,
                    Origin = "GRU",
                    Destiny = "CDG",
                    Cost = 75
                },
                new Route
                {
                    Id = 4,
                    Origin = "GRU",
                    Destiny = "SCL",
                    Cost = 20
                },
                new Route
                {
                    Id = 5,
                    Origin = "GRU",
                    Destiny = "ORL",
                    Cost = 56
                },
                new Route
                {
                    Id = 6,
                    Origin = "ORL",
                    Destiny = "CDG",
                    Cost = 5
                },
                new Route
                {
                    Id = 7,
                    Origin = "SCL",
                    Destiny = "ORL",
                    Cost = 20
                }
            );
        }

        public DbSet<Place> Place { get; set; }

        public DbSet<Route> Route { get; set; }
    }
}
