using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BestCostRouteFinder.Application.UseCases.V1
{
    public class RouteOperations : IRouteOperations
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IRouteCalulatorService _routeCalculatorService;

        public RouteOperations(IRouteRepository routeRepository, IRouteCalulatorService routeCalculatorService)
        {
            _routeRepository = routeRepository;
            _routeCalculatorService = routeCalculatorService;
        }

        public BestRouteOutput GetBestRoute(string origin, string destiny)
        {
            IEnumerable<Route> availableRoutes = _routeRepository
                .GetAll()
                .Where(r => r.Origin == origin)
                .ToList();

            if (!availableRoutes.Any())
                return new BestRouteOutput() { RouteSequence = null, TotalCost = 0 };

            IDictionary<string, List<Route>> routeDictionary = new Dictionary<string, List<Route>>();

            foreach (Route currentRoute in availableRoutes)
            {
                string key = $"{currentRoute.Origin}-{currentRoute.Destiny}";

                List<Route> routes = new();
                List<Route> finalRoutes = new();
                _routeCalculatorService.Calculate(currentRoute, routes, finalRoutes, destiny);
                
                routeDictionary.Add(key, routes);
            }

            return new BestRouteOutput() { RouteSequence = null, TotalCost = 0 };
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
