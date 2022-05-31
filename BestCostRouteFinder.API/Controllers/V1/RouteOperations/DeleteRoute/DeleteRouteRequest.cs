using System.ComponentModel.DataAnnotations;

namespace BestCostRouteFinder.API.Controllers.V1.RouteOperations.DeleteRoute
{
    public class DeleteRouteRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
