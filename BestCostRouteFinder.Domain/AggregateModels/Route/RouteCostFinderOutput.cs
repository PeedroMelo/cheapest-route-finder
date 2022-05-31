using System.Collections.Generic;

namespace BestCostRouteFinder.Domain.AggregateModels.Route
{
    public class RouteCostFinderOutput
    {
        /// <summary>
        /// The sequence of routes that composite the final route
        /// </summary>
        public List<Route> RouteSequence { get; set; }

        /// <summary>
        /// The total cost of the route
        /// </summary>
        public decimal TotalCost { get; set; }
    }
}
