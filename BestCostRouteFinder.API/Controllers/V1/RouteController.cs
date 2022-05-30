using BestCostRouteFinder.Domain.AggregateModels.Route;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BestCostRouteFinder.API.Controllers.V1
{
    [ApiController]
    [Route("v1/routes")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository _routeRepository;

        public RouteController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        [HttpGet("")]
        public IEnumerable<Route> GetAvailableRoutes()
        {
            IEnumerable<Route> availableRoutes = _routeRepository.GetAll();

            return availableRoutes;
        }
    }
}
