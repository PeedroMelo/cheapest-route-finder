using CheapestRouteFinder.Domain.AggregateModels.Route;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CheapestRouteFinder.Infrastructure.EFCoreDataAccess.Configurations
{
    public class RoutesConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder
                .HasKey(r => r.Id)
                .HasName("PK_Route_Id");

            builder
                .Property(r => r.Id)
                .ValueGeneratedOnAdd();

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Route> builder)
        {
            builder.HasData(
                new Route
                (
                    id: 1,
                    origin: "GRU",
                    destiny: "BRC",
                    cost: 10
                ),
                new Route
                (
                    id: 2,
                    origin: "BRC",
                    destiny: "SCL",
                    cost: 5
                ),
                new Route
                (
                    id: 3,
                    origin: "GRU",
                    destiny: "CDG",
                    cost: 75
                ),
                new Route
                (
                    id: 4,
                    origin: "GRU",
                    destiny: "SCL",
                    cost: 20
                ),
                new Route
                (
                    id: 5,
                    origin: "GRU",
                    destiny: "ORL",
                    cost: 56
                ),
                new Route
                (
                    id: 6,
                    origin: "ORL",
                    destiny: "CDG",
                    cost: 5
                ),
                new Route
                (
                    id: 7,
                    origin: "SCL",
                    destiny: "ORL",
                    cost: 20
                )
            );
        }
    }
}
