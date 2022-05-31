using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestCostRouteFinder.Application.UseCases.V1.RouteOperations
{
    public class RouteOperations : IRouteOperations
    {
        private readonly IRouteRepository _routeRepository;

        public RouteOperations(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public IEnumerable<Route> GetAvailableRoutes()
        {
            return _routeRepository.GetAll();
        }

        public Route CreateRoute(Route input)
        {
            try
            {
                Route createdRoute = _routeRepository.Add(input);
                _routeRepository.SaveChanges();

                return createdRoute;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteRoute(int id)
        {
            try
            {
                Route route = _routeRepository.GetById(id);
                if (route != null)
                {
                    _routeRepository.Remove(route);
                    _routeRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
