using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPGroup.Services.ViewModels.MVCModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayName("Salary Min")]
        public decimal SalaryMin { get; set; }

        [Required]
        [DisplayName("Salary Max")]
        public decimal SalaryMax { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
