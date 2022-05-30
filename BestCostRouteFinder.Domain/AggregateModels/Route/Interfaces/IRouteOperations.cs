using System.Collections.Generic;

namespace BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces
{
    public interface IRouteOperations
    {
        /// <summary>
        /// Gets the best (cheaper) route given the origin and destiny provided
        /// </summary>
        /// <param name="origin">The origin point</param>
        /// <param name="destiny">The destiny point</param>
        /// <returns>The best route containing the list of destinations and the final cost</returns>
        BestRouteOutput GetBestRoute(string origin, string destiny);

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

        /// <summary>
        /// Updates the route properties
        /// </summary>
        /// <param name="route">The route properties to be updated</param>
        /// <returns>The route with its updated values</returns>
        Route UpdateRoute(Route route);

        /// <summary>
        /// Deletes a route by the provided id
        /// </summary>
        /// <param name="id">The route id to be deleted</param>
        void DeleteRoute(int id);
    }
}
