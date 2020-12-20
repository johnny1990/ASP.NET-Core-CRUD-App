
using CabAutomationSystem.Contracts;
using CabAutomationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabAutomationSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CabDbContext _dbContext;

        public EmployeeRepository(CabDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteEmployee(int EmployeeId)
        {
            var emp = _dbContext.Employee.Find(EmployeeId);
            _dbContext.Employee.Remove(emp);
            Save();
        }

        public Employee GetEmployeeByID(int empId)
        {
            return _dbContext.Employee.Find(empId);
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return _dbContext.Employee.ToList();
        }

        public void InsertEmployee(Employee emp)
        {
            _dbContext.Add(emp);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateEmployee(Employee emp)
        {
            _dbContext.Entry(emp).State = EntityState.Modified;
            Save();
        }
    }
}
