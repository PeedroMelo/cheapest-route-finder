using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BestCostRouteFinder.API.Controllers.V1.RouteCostFinder
{
    [ApiController]
    [Route("v1/cheapest-route-cost")]
    public class RouteCostFinderController : ControllerBase
    {
        private readonly IRouteCostFinder _useCase;

        public RouteCostFinderController(IRouteCostFinder useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RouteCostFinderResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ValidationProblemDetails))]
        public IActionResult GetCheapestRouteCost([FromQuery] RouteCostFinderRequest input)
        {
            List<Route> result = _useCase.FindCheapestRouteCost(input.Origin, input.Destiny);
            if (result.Count == 0)
                return NotFound();

            return Ok(new RouteCostFinderResponse(result));
        }
    }
}
