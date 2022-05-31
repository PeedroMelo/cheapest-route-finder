using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using BestCostRouteFinder.Infrastructure.EFCoreDataAccess.Context;

namespace BestCostRouteFinder.Infrastructure.EFCoreDataAccess.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Route CreateRoute(string origin, string destiny, decimal cost)
        {
            try
            {
                Route route = new(
                    origin: origin,
                    destiny: destiny,
                    cost: cost
                );

                Route createdRoute = Add(route);
                SaveChanges();

                return createdRoute;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}
