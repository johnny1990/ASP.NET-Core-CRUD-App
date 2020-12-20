
using CabAutomationSystem.Contracts;
using CabAutomationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace Api.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepository;

        public EmployeesController(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            var emp = _empRepository.GetEmployee();
            return new OkObjectResult(emp);
        }

        [HttpGet("{id}", Name = "GeEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            var emp = _empRepository.GetEmployeeByID(id);
            return new OkObjectResult(emp);
        }

        [HttpPost]
        public IActionResult PostEmployee([FromBody] Employee emp)
        {
            using (var scope = new TransactionScope())
            {
                _empRepository.InsertEmployee(emp);
                scope.Complete();
                return CreatedAtAction(nameof(GetEmployees), new { id = emp.EmpId }, emp);
            }
        }

        [HttpPut]
        public IActionResult PutEmployee([FromBody] Employee emp)
        {
            if (emp != null)
            {
                using (var scope = new TransactionScope())
                {
                    _empRepository.UpdateEmployee(emp);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _empRepository.DeleteEmployee(id);
            return new OkResult();
        }
    }
}
