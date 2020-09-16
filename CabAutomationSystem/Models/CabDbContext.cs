using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabAutomationSystem.Models
{
    public class CabDbContext : DbContext
    {
        public CabDbContext(DbContextOptions<CabDbContext> options) : base(options)
        {
        }

        public DbSet<Cab> Cab { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<DropPoint> DropPoint { get; set; }
    }
}
