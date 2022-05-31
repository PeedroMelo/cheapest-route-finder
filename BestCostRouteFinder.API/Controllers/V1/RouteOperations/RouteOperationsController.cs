using BestCostRouteFinder.API.Controllers.V1.RouteOperations.AddRoute;
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
        public IActionResult GetAvailableRoutes()
        {
            return Ok(_useCase.GetAvailableRoutes());
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Route))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ValidationProblemDetails))]
        public IActionResult CreateRoute([FromBody] AddRouteRequest request)
        {
            Route route = new(
                    origin: request.Origin,
                    destiny: request.Destiny,
                    cost: request.Cost);

            return Created("", _useCase.CreateRoute(route));
        }
    }
}
