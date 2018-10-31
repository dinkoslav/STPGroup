using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPGroup.Services.ViewModels.MVCModels
{
    public class CompanyDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [DisplayName("Salary Min")]
        public decimal SalaryMin { get; set; }

        [DisplayName("Salary Max")]
        public decimal SalaryMax { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public IList<EmployeeViewModel> Employees { get; set; }
    }
}
