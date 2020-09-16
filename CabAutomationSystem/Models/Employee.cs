using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CabAutomationSystem.Models
{
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "EmployeeName is required")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "EmployeeNo is required")]
        public int EmployeeNo { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
  
        [DataType(DataType.Password)]
 
        public string Password { get; set; }

  

        [Required(ErrorMessage = "ProjectName is required")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        #region m->1 Relation between Cab

        public int CabId { get; set; }

        public virtual Cab Cab { get; set; }
        #endregion
    }
}
