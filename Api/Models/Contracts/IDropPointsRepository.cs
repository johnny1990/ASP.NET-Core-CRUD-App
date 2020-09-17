using CabAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Contracts
{
    public interface IDropPointsRepository
    {
        IEnumerable<DropPoint> GetPoints();
        DropPoint GetPointByID(int dpId);
        void InsertPoint(DropPoint dp);
        void DeletePoint(int dpId);
        void UpdatePoint(DropPoint dp);
        void Save();
    }
}
