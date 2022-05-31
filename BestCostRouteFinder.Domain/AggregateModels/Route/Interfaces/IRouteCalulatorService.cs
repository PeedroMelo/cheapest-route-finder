using System.Collections.Generic;

namespace CheapestRouteFinder.Domain.AggregateModels.Route.Interfaces
{
    public interface IRouteCalulatorService
    {
        /// <summary>
        /// Recursively calculates if there is a route available with the given parameters
        /// and if the final destination is the expected final destination
        /// </summary>
        /// <param name="route">The current route</param>
        /// <param name="finalDestiny">The current route</param>
        /// <returns>The next route concatenated with the current route</returns>
        List<Route> Calculate(Route route, string finalDestiny);
    }
}
