using BestCostRouteFinder.API.Controllers.V1.RouteOperations.AddRoute;
using BestCostRouteFinder.API.Controllers.V1.RouteOperations.DeleteRoute;
using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            try
            {
                Route route = new(
                    request.Origin,
                    request.Destiny,
                    request.Cost);

                return Created("", _useCase.CreateRoute(route));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "A error ocurred while trying to create a new route.");
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ValidationProblemDetails))]
        public IActionResult DeleteRoute([FromRoute] DeleteRouteRequest request)
        {
            try
            {
                _useCase.DeleteRoute(request.Id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"A error ocurred while trying to delete the given route. (RouteID: {request.Id})");
            }
        }
    }
}
