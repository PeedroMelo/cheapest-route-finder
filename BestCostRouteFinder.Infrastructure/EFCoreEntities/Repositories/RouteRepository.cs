﻿using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Infrastructure.Context;

namespace BestCostRouteFinder.Infrastructure.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}