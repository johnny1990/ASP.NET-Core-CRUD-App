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
        [Route("GetCabs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCabs()
        {
            var cabs = _cabRepository.GetCabs();
            return new OkObjectResult(cabs);
        }

        [HttpGet("{id}", Name = "GetCabsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCabsById(int id)
        {
            var cab = _cabRepository.GetCabByID(id);
            return new OkObjectResult(cab);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PostCabs([FromBody] Cab cab)
        {
            using (var scope = new TransactionScope())
            {
                _cabRepository.InsertCab(cab);
                scope.Complete();
                return CreatedAtAction(nameof(GetCabs), new { id = cab.BookId }, cab);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PutCabs([FromBody] Cab cab)
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCabs(int id)
        {
            _cabRepository.DeleteCab(id);
            return new NoContentResult();
        }
    }
}
