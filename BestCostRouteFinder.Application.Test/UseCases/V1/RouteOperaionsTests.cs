using BestCostRouteFinder.Application.UseCases.V1.RouteOperations;
using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BestCostRouteFinder.Application.Test.UseCases.V1
{
    public class RouteOperaionsTests
    {
        private readonly List<Route> _stubData = GetStubData();
        private readonly Mock<IRouteRepository> _mockRepository;

        public RouteOperaionsTests()
        {
            _mockRepository = new Mock<IRouteRepository>();
        }

        //// Get
        [Fact]
        public void RouteOperationsGetRoutes_WithValidConstructor_ShouldReturnAListOfRoutes()
        {
            _mockRepository.Setup(r => r.GetAll()).Returns(_stubData);

            IRouteOperations routeOperations = new RouteOperations(_mockRepository.Object);

            IEnumerable<Route> routes = routeOperations.GetAvailableRoutes();
            Assert.Equal(7, routes.Count());

            Route firstRoute = routes.FirstOrDefault();
            Assert.Equal("GRU", firstRoute.Origin);
            Assert.Equal("BRC", firstRoute.Destiny);
            Assert.Equal(10, firstRoute.Cost);
        }

        //// Create
        [Fact]
        public void RouteOperationsCreateRoute_WithNewOriginAndDestiny_ShouldCreateANewRoute()
        {

        }

        [Fact]
        public void RouteOperationsCreateRoute_WithExistentOriginAndDestiny_ShouldThrowAnException()
        {

        }

        //// Delete
        [Fact]
        public void RouteOperationsDeleteRoute_WithValidConstructor_ShouldDeleteARoute()
        {

        }


        /// Update
        [Fact]
        public void RouteOperationsUpdateRoute_WithNewOriginAndDestiny_ShouldUpdateANewRoute()
        {

        }

        [Fact]
        public void RouteOperationsUpdateRoute_WithSameOriginAndDestinyAndDifferentCost_ShouldUpdateTheCost()
        {

        }

        [Fact]
        public void RouteOperationsUpdateRoute_WithExistentOriginAndDestiny_ShouldThrowAnException()
        {

        }

        private static List<Route> GetStubData()
        {
            return new List<Route>()
            {
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
            };
        }
    }
}
