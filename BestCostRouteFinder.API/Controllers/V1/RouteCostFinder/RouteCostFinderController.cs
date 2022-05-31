using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BestCostRouteFinder.API.Controllers.V1.RouteCostFinder
{
    [ApiController]
    [Route("v1/route-cost-finder")]
    public class RouteCostFinderController : ControllerBase
    {
        private readonly IRouteCostFinder _useCase;

        public RouteCostFinderController(IRouteCostFinder useCase)
        {
            _useCase = useCase;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RouteCostFinderResponse))]
        public ActionResult<RouteCostFinderResponse> GetAvailableRoutes([FromQuery] RouteCostFinderRequest input)
        {
            List<Route> result = _useCase.FindCheapestRouteCost(input.Origin, input.Destiny);

            return new RouteCostFinderResponse(result);
        }
    }
}
