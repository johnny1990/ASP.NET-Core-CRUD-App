using CabAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Contracts
{
    public interface ICabRepository
    {
        IEnumerable<Cab> GetCabs();
        Cab GetCabByID(int cabId);
        void InsertCab(Cab cab);
        void DeleteCab(int cabId);
        void UpdateCab(Cab cab);
        void Save();
    }
}
