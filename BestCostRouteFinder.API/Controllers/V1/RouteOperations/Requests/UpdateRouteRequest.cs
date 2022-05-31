using System.ComponentModel.DataAnnotations;

namespace BestCostRouteFinder.API.Controllers.V1.RouteOperations.Requests
{
    public class UpdateRouteRequest
    {
        /// <summary>
        /// The orgin that can be updated
        /// </summary>
        [MaxLength(3)]
        public string Origin { get; set; }

        /// <summary>
        /// The destiny that can be updated
        /// </summary>
        [MaxLength(3)]
        public string Destiny { get; set; }

        /// <summary>
        /// The cost that can be updated
        /// </summary>
        public decimal Cost { get; set; }
    }
}
