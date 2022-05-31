using BestCostRouteFinder.Application.UseCases.V1.RouteOperations;
using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using Moq;
using System;
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
            Route newRoute = new(
                origin: "TST",
                destiny: "TSV",
                cost: 10);

            _mockRepository.Setup(r => r.GetAll()).Returns(_stubData);

            _mockRepository.Setup(r => r.Add(It.IsAny<Route>())).Returns(newRoute);

            IRouteOperations routeOperations = new RouteOperations(_mockRepository.Object);

            Route createdRoute = routeOperations.CreateRoute(newRoute);

            Assert.Equal(newRoute.Origin, createdRoute.Origin);
            Assert.Equal(newRoute.Destiny, createdRoute.Destiny);
            Assert.Equal(newRoute.Cost, createdRoute.Cost);
        }

        [Fact]
        public void RouteOperationsCreateRoute_WithExistentOriginAndDestiny_ShouldThrowAnException()
        {
            Route oldRoute = new(
                id: 1,
                origin: "GRU",
                destiny: "BRC",
                cost: 10);

            Route newRoute = new(
                origin: "GRU",
                destiny: "BRC",
                cost: 10);

            _mockRepository.Setup(r => r.GetAll()).Returns(_stubData);

            _mockRepository.Setup(r => r.Add(It.IsAny<Route>())).Returns(oldRoute);

            IRouteOperations routeOperations = new RouteOperations(_mockRepository.Object);

            var ex = Assert.Throws<ArgumentException>(() => routeOperations.CreateRoute(newRoute));
            Assert.Equal($"The route {newRoute.Origin}-{newRoute.Destiny} already exists.", ex.Message);
        }

        /// Update
        [Fact]
        public void RouteOperationsUpdateRoute_WithNewOriginAndDestiny_ShouldUpdateANewRoute()
        {
            Route oldRoute = new(
                id: 6,
                origin: "ORL",
                destiny: "CDG",
                cost: 5);

            Route newRoute = new(
                origin: "ORL",
                destiny: "BRC",
                cost: 15);

            _mockRepository.Setup(r => r.GetAll()).Returns(_stubData);

            _mockRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(oldRoute);

            IRouteOperations routeOperations = new RouteOperations(_mockRepository.Object);

            Route createdRoute = routeOperations.UpdateRoute(oldRoute.Id, newRoute);

            Assert.Equal("BRC", newRoute.Destiny);
            Assert.Equal(15, newRoute.Cost);
        }

        [Fact]
        public void RouteOperationsUpdateRoute_WithSameOriginAndDestinyAndDifferentCost_ShouldUpdateTheCost()
        {
            Route oldRoute = new(
                id: 6,
                origin: "ORL",
                destiny: "CDG",
                cost: 5);

            Route newRoute = new(
                origin: "ORL",
                destiny: "CDG",
                cost: 15);

            _mockRepository.Setup(r => r.GetAll()).Returns(_stubData);

            _mockRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(oldRoute);

            IRouteOperations routeOperations = new RouteOperations(_mockRepository.Object);

            Route createdRoute = routeOperations.UpdateRoute(oldRoute.Id, newRoute);

            Assert.Equal(oldRoute.Origin, newRoute.Origin);
            Assert.Equal(oldRoute.Destiny, newRoute.Destiny);
            Assert.Equal(15, newRoute.Cost);
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
