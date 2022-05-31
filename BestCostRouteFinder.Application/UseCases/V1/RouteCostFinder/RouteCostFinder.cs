using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BestCostRouteFinder.Application.UseCases.V1.RouteCostFinder
{
    public class RouteCostFinder : IRouteCostFinder
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IRouteCalulatorService _routeCalculatorService;

        public RouteCostFinder(IRouteRepository routeRepository, IRouteCalulatorService routeCalculatorService)
        {
            _routeRepository = routeRepository;
            _routeCalculatorService = routeCalculatorService;
        }

        public List<Route> FindCheapestRouteCost(string origin, string destiny)
        {
            List<Route> result = new();

            IEnumerable<Route> availableRoutes = _routeRepository
                .GetAll()
                .Where(r => r.Origin == origin)
                .ToList();

            if (!availableRoutes.Any())
                return result;

            List<List<Route>> calculatedRoutes = new();

            foreach (Route currentRoute in availableRoutes)
            {
                List<Route> routes = _routeCalculatorService.Calculate(currentRoute, destiny);

                calculatedRoutes.Add(routes);
            }

            decimal totalCost = 0;

            foreach (List<Route> entry in calculatedRoutes)
            {
                if (entry.Count == 0)
                    continue;

                // Get by default the value of the first element
                if (entry == calculatedRoutes.First())
                {
                    totalCost = entry.Sum(r => r.Cost);
                    result = entry;
                    continue;
                }

                if (totalCost > entry.Sum(r => r.Cost))
                {
                    totalCost = entry.Sum(r => r.Cost);
                    result = entry;
                }
            }

            return result;
        }
    }
}
