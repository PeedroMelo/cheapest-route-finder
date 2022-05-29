using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BestCostRouteFinder.API.Controllers.V1
{
    [ApiController]
    [Route("v1/routes")]
    public class RouteController : ControllerBase
    {
        [HttpGet("")]
        public List<string> GetAvailableRoutes()
        {
            List<string> availableRoutes = new()
            {
                "Origem: GRU, Destino: BRC, Valor: 10",
                "Origem: BRC, Destino: SCL, Valor: 5",
                "Origem: GRU, Destino: CDG, Valor: 75",
                "Origem: GRU, Destino: SCL, Valor: 20",
                "Origem: GRU, Destino: ORL, Valor: 56",
                "Origem: ORL, Destino: CDG, Valor: 5",
                "Origem: SCL, Destino: ORL, Valor: 20"
            };

            return availableRoutes;
        }
    }
}
