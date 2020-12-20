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
    [Route("api/DropPoints")]
    [ApiController]
    public class DropPointsController : ControllerBase
    {
        private readonly IDropPointsRepository _dpRepository;

        public DropPointsController(IDropPointsRepository dpRepository)
        {
            _dpRepository = dpRepository;
        }

        [HttpGet]
        [Route("GetDropPoints")]
        public IActionResult GetDropPoints()
        {
            var dp = _dpRepository.GetPoints();
            return new OkObjectResult(dp);
        }

        [HttpGet("{id}", Name = "GetDropPointsById")]
        public IActionResult GetDropPointstById(int id)
        {
            var cab = _dpRepository.GetPointByID(id);
            return new OkObjectResult(cab);
        }

        [HttpPost]
        public IActionResult PostDropPoints([FromBody] DropPoint dp)
        {
            using (var scope = new TransactionScope())
            {
                _dpRepository.InsertPoint(dp);
                scope.Complete();
                return CreatedAtAction(nameof(GetDropPoints), new { id = dp.DropPointId}, dp);
            }
        }

        [HttpPut]
        public IActionResult PutDropPoints([FromBody] DropPoint dp)
        {
            if (dp != null)
            {
                using (var scope = new TransactionScope())
                {
                    _dpRepository.UpdatePoint(dp);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDropPoints(int id)
        {
            _dpRepository.DeletePoint(id);
            return new OkResult();
        }
    }
}
