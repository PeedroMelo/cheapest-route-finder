using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using System;
using System.Collections.Generic;

namespace BestCostRouteFinder.Application.UseCases.V1.RouteOperations
{
    public class RouteOperations : IRouteOperations
    {
        private readonly IRouteRepository _routeRepository;

        public RouteOperations(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public IEnumerable<Route> GetAvailableRoutes()
        {
            return _routeRepository.GetAll();
        }

        public Route CreateRoute(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
