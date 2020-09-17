using Api.Models.Contracts;
using CabAutomationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Repository
{
    public class CabRepository : ICabRepository
    {
        private readonly CabDbContext _dbContext;

        public CabRepository(CabDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCab(int productId)
        {
            var cab = _dbContext.Cab.Find(productId);
            _dbContext.Cab.Remove(cab);
            Save();
        }

        public Cab GetCabByID(int cabId)
        {
            return _dbContext.Cab.Find(cabId);
        }

        public IEnumerable<Cab> GetCabs()
        {
            return _dbContext.Cab.ToList();
        }

        public void InsertCab(Cab cab)
        {
            _dbContext.Add(cab);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateCab(Cab cab)
        {
            _dbContext.Entry(cab).State = EntityState.Modified;
            Save();
        }
    }
}
