using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using System;
using System.Collections.Generic;

namespace BestCostRouteFinder.Application.UseCases.V1
{
    public class RouteOperations : IRouteOperations
    {
        private readonly IRouteRepository _routeRepository;

        public RouteOperations(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public Route CreateRoute(Route route)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoute(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Route> GetAvailableRoutes()
        {
            return _routeRepository.GetAll();
        }

        public Route UpdateRoute(Route route)
        {
            throw new NotImplementedException();
        }
    }
}
