using BestCostRouteFinder.Domain.Interfaces;

namespace BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        /// <summary>
        /// Creates a new route
        /// </summary>
        /// <param name="origin">The origin point</param>
        /// <param name="destiny">The destiny point</param>
        /// <param name="cost">The cost of the route</param>
        /// <returns>The created route</returns>
        Route CreateRoute(string origin, string destiny, decimal cost);
    }
}
