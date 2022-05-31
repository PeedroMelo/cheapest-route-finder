namespace BestCostRouteFinder.API.Controllers.V1.RouteOperations.AddRoute
{
    public class AddRouteRequest
    {
        public string Origin { get; set; }

        public string Destiny { get; set; }

        public decimal Cost { get; set; }
    }
}
