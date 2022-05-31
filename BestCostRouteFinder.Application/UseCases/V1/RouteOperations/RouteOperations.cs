using BestCostRouteFinder.Domain.AggregateModels.Route;
using BestCostRouteFinder.Domain.AggregateModels.Route.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
                // Checks if there is any other route with the same Origin and Destiny
                Route existentRoute = _routeRepository
                    .GetAll()
                    .Where(r => r.Origin == input.Origin && r.Destiny == input.Destiny)
                    .FirstOrDefault();

                if (existentRoute != null)
                    throw new ArgumentException($"The route {input.Origin}-{input.Destiny} already exists.");

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

        public Route UpdateRoute(int id, Route newValuedRoute)
        {
            try
            {
                Route route = _routeRepository.GetById(id);

                // Checks if there is any other route with the same Origin and Destiny
                Route existentRoute = _routeRepository
                    .GetAll()
                    .Where(r => r.Id != id && r.Origin == newValuedRoute.Origin && r.Destiny == newValuedRoute.Destiny)
                    .FirstOrDefault();

                if (existentRoute != null)
                    throw new ArgumentException($"The route {newValuedRoute.Origin}-{newValuedRoute.Destiny} already exists.");

                if (route != null)
                {
                    route.Origin = newValuedRoute.Origin;
                    route.Destiny = newValuedRoute.Destiny;
                    route.Cost = newValuedRoute.Cost;

                    _routeRepository.SaveChanges();
                }

                return route;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
