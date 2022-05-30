using System.Collections.Generic;

namespace BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces
{
    public interface IRouteCalulatorService
    {
        /// <summary>
        /// Recursively calculates if there is a route available with the given parameters
        /// and if the final destination is the expected final destination
        /// </summary>
        /// <param name="route">The current route</param>
        /// <param name="routes">The current route</param>
        /// <param name="finalDestiny">The current route</param>
        /// <returns>The next route concatenated with the current route</returns>
        List<Route> Calculate(Route route, List<Route> routes, List<Route> finalRoutes, string finalDestiny);
    }
}
