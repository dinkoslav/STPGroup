namespace STPGroup.WebServices.Interfaces
{
    using STPGroup.Services.ViewModels.ApiModels;
    using System.Collections.Generic;

    public interface ISTPGroupWebService
    {
        IList<CompanyModel> GetAllCompanies();

        CompanyModel GetCompanyById(int id);

        void AddCompany(CompanyModel model);

        void UpdateCompany(CompanyModel model);

        void DeleteCompany(CompanyModel model);

        void AddEmployee(EmployeeModel model);

        void DeleteEmployee(EmployeeModel model);

        EmployeeModel GetEmployeeById(int id);

        void UpdateEmployee(EmployeeModel model);
    }
}
