using STPGroup.MVCServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STPGroup.Services.ViewModels.MVCModels;
using STPGroup.WebServices.Interfaces;
using STPGroup.Services.Infrastructure.Interfaces;
using STPGroup.Services.ViewModels.ApiModels;

namespace STPGroup.MVCServices
{
    public class EmployeesMVCService : IEmployeesMVCService
    {
        private readonly ISTPGroupWebService stpGroupWebService;
        private readonly IMapperService mapperService;

        public EmployeesMVCService(ISTPGroupWebService stpGroupWebService, IMapperService mapperService)
        {
            this.stpGroupWebService = stpGroupWebService;
            this.mapperService = mapperService;
        }

        public void AddEmployee(EmployeeViewModel viewModel)
        {
            EmployeeModel model = this.mapperService.Map<EmployeeViewModel, EmployeeModel>(viewModel);
            this.stpGroupWebService.AddEmployee(model);
        }

        public bool SalaryIsValid(EmployeeViewModel viewModel)
        {
            CompanyModel companyModel = this.stpGroupWebService.GetCompanyById(viewModel.CompanyId);

            return viewModel.Salary >= companyModel.SalaryMin && viewModel.Salary <= companyModel.SalaryMax;
        }

        public void SetDeleteEmployee(EmployeeViewModel viewModel)
        {
            EmployeeModel model = this.mapperService.Map<EmployeeViewModel, EmployeeModel>(viewModel);
            this.stpGroupWebService.DeleteEmployee(model);
        }

        public EmployeeViewModel GetDeleteEmployee(int id)
        {
            EmployeeModel employeeModel = this.stpGroupWebService.GetEmployeeById(id);
            EmployeeViewModel viewModel = this.mapperService.Map<EmployeeModel, EmployeeViewModel>(employeeModel);

            return viewModel;
        }

        public void SetEditEmployee(EmployeeViewModel viewModel)
        {
            EmployeeModel model = this.mapperService.Map<EmployeeViewModel, EmployeeModel>(viewModel);
            this.stpGroupWebService.UpdateEmployee(model);
        }

        public EmployeeViewModel GetEditEmployee(int id)
        {
            EmployeeModel employeeModel = this.stpGroupWebService.GetEmployeeById(id);
            EmployeeViewModel viewModel = this.mapperService.Map<EmployeeModel, EmployeeViewModel> (employeeModel);

            return viewModel;
        }
    }
}
