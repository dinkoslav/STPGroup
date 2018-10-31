namespace STPGroup.Services.ViewModels.MVCModels
{
    using System;
    using System.ComponentModel;

    public class CompanyGridViewModel
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

        [DisplayName("Employees Count")]
        public int EmployeesCount { get; set; }
    }
}
