using CabAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeByID(int empId);
        void InsertEmployee(Employee emp);
        void DeleteEmployee(int empId);
        void UpdateEmployee(Employee emp);
        void Save();
    }
}
