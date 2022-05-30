using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BestCostRouteFinder.Application.Services
{
    public class RouteCalculatorService : IRouteCalulatorService
    {
        private readonly IRouteRepository _routeRepository;
        
        public RouteCalculatorService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public List<Route> Calculate(Route route, List<Route> routes, List<Route> finalRoutes, string finalDestiny)
        {
            if (route == null)
                return null;

            IEnumerable<Route> availableRoutes = _routeRepository
                .GetAll()
                .Where(r => r.Origin == route.Destiny)
                .ToList();

            foreach (Route nextRoute in availableRoutes)
            {
                if (nextRoute.Destiny == finalDestiny)
                {
                    finalRoutes.Append(nextRoute);
                    break;
                }
                finalRoutes.Concat(Calculate(nextRoute, routes, finalRoutes, finalDestiny));
            }

            return routes;
        }
    }
}
