using Api.Models.Contracts;
using CabAutomationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Repository
{
    public class DropPointsRepository : IDropPointsRepository
    {
        private readonly CabDbContext _dbContext;

        public DropPointsRepository(CabDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeletePoint(int dpId)
        {
            var dp = _dbContext.DropPoint.Find(dpId);
            _dbContext.DropPoint.Remove(dp);
            Save();
        }

        public DropPoint GetPointByID(int dpId)
        {
            return _dbContext.DropPoint.Find(dpId);
        }

        public IEnumerable<DropPoint> GetPoints()
        {
            return _dbContext.DropPoint.ToList();
        }

        public void InsertPoint(DropPoint dp)
        {
            _dbContext.Add(dp);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdatePoint(DropPoint dp)
        {
            _dbContext.Entry(dp).State = EntityState.Modified;
            Save();
        }
    }
}
