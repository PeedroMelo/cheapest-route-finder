using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using BestCostRouteFinder.Infrastructure.Context;

namespace BestCostRouteFinder.Infrastructure.Repositories
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
                Route route = new()
                {
                    Origin = origin,
                    Destiny = destiny,
                    Cost = cost
                };

                Route createdRoute = Add(route);
                _context.SaveChanges();

                return createdRoute;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void DeleteRoute(int id)
        {
            throw new System.NotImplementedException();
        }

        public Route UpdateRoute(Route route)
        {
            throw new System.NotImplementedException();
        }
    }
}
