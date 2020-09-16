using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabAutomationSystem.Models
{

    public class DropPoint
    {
        [ScaffoldColumn(false)]
        public int DropPointId { get; set; }

        [Required(ErrorMessage = "DropPointName is required")]
        public string DropPointName { get; set; }

        public string NewDropPointName { get; set; }



        #region m->1Relation between Route
        [DisplayName("Route")]
        public int RouteId { get; set; }

        public virtual Route Route { get; set; }
        #endregion
    }
}
