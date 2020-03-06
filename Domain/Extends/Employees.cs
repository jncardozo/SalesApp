using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [MetadataType(typeof(EmployeesMetadata))]
    public partial class Employees
    {
        #region Properties
        public string CompleteName => $"{Name} {Surname}";        
        #endregion
    }

    public class EmployeesMetadata
    {
        [Required(ErrorMessage = "Field Employee Name is required ")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field Employee Surname is required ")]
        [Display(Name = "Employee Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Field Document Number is required ")]
        [Display(Name = "Document Number")]
        public string DocNum { get; set; }

        [Display(Name = "Birth Day")]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [Display(Name = "Age of Employee")]
        public Nullable<int> Age { get; set; }

        [Required(ErrorMessage = "Field File Number is required ")]
        [Display(Name = "File Number")]
        public string FileNumber { get; set; }
    }

}

