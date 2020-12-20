
using CabAutomationSystem.Contracts;
using CabAutomationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabAutomationSystem.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly CabDbContext _dbContext;

        public RouteRepository(CabDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteRoute(int routeId)
        {
            var route = _dbContext.Route.Find(routeId);
            _dbContext.Route.Remove(route);
            Save();
        }

        public Route GetRouteByID(int routeId)
        {
            return _dbContext.Route.Find(routeId);
        }

        public IEnumerable<Route> GetRoutes()
        {
            return _dbContext.Route.ToList();
        }

        public void InsertRoute(Route route)
        {
            _dbContext.Add(route);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateRoute(Route route)
        {
            _dbContext.Entry(route).State = EntityState.Modified;
            Save();
        }
    }
}
