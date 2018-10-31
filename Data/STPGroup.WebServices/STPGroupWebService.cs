namespace STPGroup.WebServices
{
    using System;
    using System.Collections.Generic;
    using Services.ViewModels.ApiModels;
    using STPGroup.WebServices.Interfaces;

    public class STPGroupWebService : ISTPGroupWebService
    {
        private const string stpGroupWebApiUrl = "http://localhost:60073/";

        private const string companiesUrl = "{0}api/companies";
        private const string companiesByIdUrl = "{0}api/companies/{1}";
        private const string companiesAddUrl = "{0}api/companies/add";
        private const string companiesUpdateUrl = "{0}api/companies/update";
        private const string companiesDeleteUrl = "{0}api/companies/delete";

        private const string employeesByIdUrl = "{0}api/employees/{1}";
        private const string employeesAddUrl = "{0}api/employees/add";
        private const string employeesUpdateUrl = "{0}api/employees/update";
        private const string employeesDeleteUrl = "{0}api/employees/delete";

        private readonly IHttpRequestService httpRequestService;

        public STPGroupWebService(IHttpRequestService httpRequestService)
        {
            this.httpRequestService = httpRequestService;
        }

        public IList<CompanyModel> GetAllCompanies()
        {
            string requestUrl = string.Format(companiesUrl, stpGroupWebApiUrl);
            IList<CompanyModel> companies = this.httpRequestService.Get<IList<CompanyModel>>(requestUrl);

            return companies;
        }

        public CompanyModel GetCompanyById(int id)
        {
            string requestUrl = string.Format(companiesByIdUrl, stpGroupWebApiUrl, id);
            CompanyModel company = this.httpRequestService.Get<CompanyModel>(requestUrl);

            return company;
        }

        public void AddCompany(CompanyModel model)
        {
            string requestUrl = string.Format(companiesAddUrl, stpGroupWebApiUrl);
            this.httpRequestService.Post<CompanyModel>(requestUrl, model, null);
        }

        public void UpdateCompany(CompanyModel model)
        {
            string requestUrl = string.Format(companiesUpdateUrl, stpGroupWebApiUrl);
            this.httpRequestService.Post<CompanyModel>(requestUrl, model, null);
        }

        public void DeleteCompany(CompanyModel model)
        {
            string requestUrl = string.Format(companiesDeleteUrl, stpGroupWebApiUrl);
            this.httpRequestService.Post<CompanyModel>(requestUrl, model, null);
        }

        public void AddEmployee(EmployeeModel model)
        {
            string requestUrl = string.Format(employeesAddUrl, stpGroupWebApiUrl);
            this.httpRequestService.Post<EmployeeModel>(requestUrl, model, null);
        }

        public void DeleteEmployee(EmployeeModel model)
        {
            string requestUrl = string.Format(employeesDeleteUrl, stpGroupWebApiUrl);
            this.httpRequestService.Post<EmployeeModel>(requestUrl, model, null);
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            string requestUrl = string.Format(employeesByIdUrl, stpGroupWebApiUrl, id);
            EmployeeModel company = this.httpRequestService.Get<EmployeeModel>(requestUrl);

            return company;
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            string requestUrl = string.Format(employeesUpdateUrl, stpGroupWebApiUrl);
            this.httpRequestService.Post<EmployeeModel>(requestUrl, model, null);
        }
    }
}
