using BestCostRouteFinder.API.Controllers.V1.RouteOperations.Requests;
using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ValidationProblemDetails))]
        public IActionResult DeleteRoute([FromRoute] int id)
        {
            try
            {
                _useCase.DeleteRoute(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"A error ocurred while trying to delete the given route. (RouteID: {id})");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ValidationProblemDetails))]
        public IActionResult UpdateRoute([FromRoute] int id, [FromBody] UpdateRouteRequest request)
        {
            try
            {
                Route route = new(
                    request.Origin,
                    request.Destiny,
                    request.Cost);

                return Ok(_useCase.UpdateRoute(id, route));
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"A error ocurred while trying to update the given route. (RouteID: {id})");
            }
        }
    }
}
