using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BestCostRouteFinder.API.Controllers.V1.RouteOperations
{
    [ApiController]
    [Route("v1/routes")]
    public class RouteCostFinderController : ControllerBase
    {
        private readonly IRouteOperations _useCase;

        public RouteCostFinderController(IRouteOperations useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Route>))]
        public IEnumerable<Route> GetAvailableRoutes()
        {
            return _useCase.GetAvailableRoutes();
        }
    }
}
