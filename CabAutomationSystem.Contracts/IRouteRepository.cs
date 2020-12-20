using CabAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabAutomationSystem.Contracts
{
    public interface IRouteRepository
    {
        IEnumerable<Route> GetRoutes();
        Route GetRouteByID(int routeId);
        void InsertRoute(Route route);
        void DeleteRoute(int routeId);
        void UpdateRoute(Route route);
        void Save();
    }
}
