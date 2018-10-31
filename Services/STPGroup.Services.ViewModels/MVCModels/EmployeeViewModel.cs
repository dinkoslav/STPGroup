using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPGroup.Services.ViewModels.MVCModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        [Required]
        [DisplayName("Experience Level")]
        public int ExperienceLevelId { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Starting Date")]
        public DateTime StartingDate { get; set; }

        [Required]
        [DisplayName("Salary")]
        public decimal Salary { get; set; }

        [Required]
        [DisplayName("Vacation Days")]
        public int VacationDays { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
