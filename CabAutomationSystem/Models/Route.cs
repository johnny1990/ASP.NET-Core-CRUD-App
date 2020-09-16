using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabAutomationSystem.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        [Required(ErrorMessage = "RouteName is required")]
        public string RouteName { get; set; }

        [Required(ErrorMessage = "RouteNumber is required")]
        [StringLength(15, ErrorMessage = "RouteNumber Name Not exceed more than 15 words")]
        public string RouteNumber { get; set; }

        #region 1->m Relation between Route and DropPoint

        public virtual List<DropPoint> DropPoint_List { get; set; }
        #endregion
    }
}
