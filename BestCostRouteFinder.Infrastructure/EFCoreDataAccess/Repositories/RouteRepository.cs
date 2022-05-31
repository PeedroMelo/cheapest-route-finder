using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using BestCostRouteFinder.Infrastructure.EFCoreDataAccess.Context;
using System;
using System.Linq;

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
            catch (Exception)
            {
                throw;
            }
        }

        public Route GetById(int id)
        {
            try
            {
                Route route = GetAll()
                    .Where(r => r.Id == id)
                    .FirstOrDefault();

                return route;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
