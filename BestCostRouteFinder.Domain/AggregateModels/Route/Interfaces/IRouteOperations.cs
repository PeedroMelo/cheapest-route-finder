using System.Collections.Generic;

namespace BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces
{
    public interface IRouteOperations
    {
        /// <summary>
        /// Gets the available routes
        /// </summary>
        /// <returns>The list of available routes</returns>
        IEnumerable<Route> GetAvailableRoutes();

        /// <summary>
        /// Creates a new route
        /// </summary>
        /// <param name="route">The new route to be created</param>
        /// <returns>The new created route</returns>
        Route CreateRoute(Route route);
    }
}
