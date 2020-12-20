using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using CabAutomationSystem.Contracts;
using CabAutomationSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Routes")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteRepository _routeRepository;

        public RoutesController(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        [HttpGet]
        [Route("GetRoutes")]
        public IActionResult GetRoutes()
        {
            var routes = _routeRepository.GetRoutes();
            return new OkObjectResult(routes);
        }

        [HttpGet("{id}", Name = "GeRoutesById")]
        public IActionResult GetRoutesById(int id)
        {
            var route = _routeRepository.GetRouteByID(id);
            return new OkObjectResult(route);
        }

        [HttpPost]
        public IActionResult PostRoutes([FromBody] Route route)
        {
            using (var scope = new TransactionScope())
            {
                _routeRepository.InsertRoute(route);
                scope.Complete();
                return CreatedAtAction(nameof(GetRoutes), new { id = route.RouteId }, route);
            }
        }

        [HttpPut]
        public IActionResult PutRoutes([FromBody] Route route)
        {
            if (route != null)
            {
                using (var scope = new TransactionScope())
                {
                    _routeRepository.UpdateRoute(route);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoutes(int id)
        {
            _routeRepository.DeleteRoute(id);
            return new OkResult();
        }
    }
}
