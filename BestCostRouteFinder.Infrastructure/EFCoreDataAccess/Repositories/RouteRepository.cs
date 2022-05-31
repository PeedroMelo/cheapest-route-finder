using CheapestRouteFinder.Domain.AggregateModels.Route;
using CheapestRouteFinder.Domain.AggregateModels.Route.Interfaces;
using CheapestRouteFinder.Infrastructure.EFCoreDataAccess.Context;
using System;
using System.Linq;

namespace CheapestRouteFinder.Infrastructure.EFCoreDataAccess.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(ApplicationDbContext context) : base(context)
        {
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
