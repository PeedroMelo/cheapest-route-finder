using CheapestRouteFinder.Domain.AggregateModels.Route;
using Xunit;

namespace CheapestRouteFinder.Domain.Test.AggregateModels
{
    public class RouteTest
    {
        [Fact]
        public void RouteEntity_WithValidConstructor_ShouldAssingValuesWithoutException()
        {
            Route testRoute = new(
                origin: "ORT",
                destiny: "DRT",
                cost: 100
            );

            Assert.Equal("ORT", testRoute.Origin);
            Assert.Equal("DRT", testRoute.Destiny);
            Assert.Equal(100, testRoute.Cost);
        }
    }
}
