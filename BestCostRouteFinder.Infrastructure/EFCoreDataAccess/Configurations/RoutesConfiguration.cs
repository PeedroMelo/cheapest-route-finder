using BestCostRouteFinder.Domain.AggregateModels.Route;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestCostRouteFinder.Infrastructure.EFCoreDataAccess.Configurations
{
    public class RoutesConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(r => new { r.Origin, r.Destiny });

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Route> builder)
        {
            builder.HasData(
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
    }
}
