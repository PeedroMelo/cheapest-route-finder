using BestCostRouteFinder.Domain.AggregateModels.Route;
using System.Collections.Generic;
using System.Linq;

namespace BestCostRouteFinder.API.Controllers.V1.RouteCostFinder
{
    public class RouteCostFinderResponse
    {
        /// <summary>
        /// The routes that composite the cheaper route combination
        /// </summary>
        public List<Route> Routes { get; private set; }

        /// <summary>
        /// The parsed message
        /// </summary>
        public string Message { get; private set; }

        public RouteCostFinderResponse(List<Route> routes)
        {
            Routes = routes;
            Message = ParseMessage(routes);
        }

        private static string ParseMessage(List<Route> routes)
            => string.Join(" - ", routes.Select(r => r.Origin)) + " ao custo de $ " + routes.Sum(r => r.Cost);
    }
}
