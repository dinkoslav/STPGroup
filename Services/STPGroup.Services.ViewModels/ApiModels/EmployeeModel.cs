namespace STPGroup.Services.ViewModels.ApiModels
{
    using System;

    public class EmployeeModel
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        public int ExperienceLevelId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime StartingDate { get; set; }

        public decimal Salary { get; set; }

        public int VacationDays { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
