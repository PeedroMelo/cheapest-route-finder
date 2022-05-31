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

        public List<Route> Calculate(Route route, string finalDestiny)
        {
            List<Route> routes = new()
            {
                route
            };
            Calculate(route, routes, finalDestiny);

            return routes;
        }

        private void Calculate(Route route, List<Route> routes, string finalDestiny)
        {
            if (route.Destiny == finalDestiny)
                return;

            IEnumerable<Route> availableRoutes = _routeRepository
                .GetAll()
                .Where(r => r.Origin == route.Destiny)
                .ToList();

            if (!availableRoutes.Any())
            {
                routes.Clear();
                return;
            }

            foreach (Route nextRoute in availableRoutes)
            {
                routes.Add(nextRoute);
                if (nextRoute.Destiny == finalDestiny)
                    break;

                Calculate(nextRoute, routes, finalDestiny);
            }
        }
    }
}
