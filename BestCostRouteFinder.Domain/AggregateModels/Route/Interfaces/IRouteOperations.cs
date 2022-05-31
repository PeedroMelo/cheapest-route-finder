using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Deletes a route
        /// </summary>
        /// <param name="id">The id of the route to be deleted</param>
        void DeleteRoute(int id);

        /// <summary>
        /// Updates a route
        /// </summary>
        /// <param name="id">The id of the route to be updated</param>
        /// <param name="route">The route to be updated with the new values</param>
        /// <returns>The updated route</returns>
        Route UpdateRoute(int id, Route route);
    }
}
