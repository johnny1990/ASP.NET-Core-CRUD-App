using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabAutomationSystem.Models
{
    public class Cab
    {
        [ScaffoldColumn(false)]
        public int CabId { get; set; }
        public long BookId { get; set; }

        [Required(ErrorMessage = "BookTime is required")]
        public TimeSpan BookTime { get; set; }

        [Required(ErrorMessage = "JourneyTime is required")]
        public long JourneyTime { get; set; }

        [Required(ErrorMessage = "JourneyPlace is required")]
        public string JourneyPlace { get; set; }

        #region 1->m Relation between Cab and Emp
        public virtual List<Employee> Employee_List { get; set; }
        #endregion
    }
}
