using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Api.Models.Contracts;
using CabAutomationSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Cabs")]
    [ApiController]
    public class CabsController : ControllerBase
    {
        private readonly ICabRepository _cabRepository;

        public CabsController(ICabRepository cabRepository)
        {
            _cabRepository = cabRepository;
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var cabs = _cabRepository.GetCabs();
            return new OkObjectResult(cabs);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var cab = _cabRepository.GetCabByID(id);
            return new OkObjectResult(cab);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cab cab)
        {
            using (var scope = new TransactionScope())
            {
                _cabRepository.InsertCab(cab);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = cab.BookId }, cab);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Cab cab)
        {
            if (cab != null)
            {
                using (var scope = new TransactionScope())
                {
                    _cabRepository.UpdateCab(cab);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cabRepository.DeleteCab(id);
            return new OkResult();
        }
    }
}
