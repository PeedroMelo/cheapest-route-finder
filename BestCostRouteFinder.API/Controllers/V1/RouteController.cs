using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BestCostRouteFinder.API.Controllers.V1
{
    [ApiController]
    [Route("v1/routes")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteOperations _useCase;

        public RouteController(IRouteOperations useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("lower-cost")]
        public BestRouteOutput GetBestRoute([FromQuery] RouteRequestModel input)
        {
            return _useCase.GetBestRoute(input.Origin, input.Destiny);
        }

        [HttpGet("")]
        public IEnumerable<Route> GetAvailableRoutes()
        {
            return _useCase.GetAvailableRoutes();
        }
    }
}
