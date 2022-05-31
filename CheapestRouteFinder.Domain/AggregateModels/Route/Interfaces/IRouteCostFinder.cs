using System.Collections.Generic;

namespace CheapestRouteFinder.Domain.AggregateModels.Route.Interfaces
{
    public interface IRouteCostFinder
    {
        /// <summary>
        /// Finds the cheapest route combination given the origin and destiny provided
        /// </summary>
        /// <param name="origin">The origin point</param>
        /// <param name="destiny">The destiny point</param>
        /// <returns>A list of the routes that composite the cheapest cost</returns>
        List<Route> FindCheapestRouteCost(string origin, string destiny);
    }
}
