using CheapestRouteFinder.Domain.Interfaces;

namespace CheapestRouteFinder.Domain.AggregateModels.Route.Interfaces
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        // <summary>
        /// Get the route entity by the id
        /// </summary>
        /// <param name="id">The provided route id</param>
        /// <returns>A route entity</returns>
        Route GetById(int id);
    }
}
