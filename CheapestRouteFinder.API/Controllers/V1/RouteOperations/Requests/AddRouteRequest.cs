using System.ComponentModel.DataAnnotations;

namespace CheapestRouteFinder.API.Controllers.V1.RouteOperations.Requests
{
    public class AddRouteRequest
    {
        /// <summary>
        /// The new origin route point
        /// </summary>
        [Required]
        [MaxLength(3)]
        public string Origin { get; set; }

        /// <summary>
        /// The new destiny route point
        /// </summary>
        [Required]
        [MaxLength(3)]
        public string Destiny { get; set; }

        /// <summary>
        /// The cost of the route
        /// </summary>
        [Required]
        public decimal Cost { get; set; }
    }
}
