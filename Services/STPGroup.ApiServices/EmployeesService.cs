namespace STPGroup.ApiServices
{
    using System;
    using STPGroup.ApiServices.Interfaces;
    using Services.ViewModels.ApiModels;
    using Data.DataHandlers.Interfaces;
    using Services.Infrastructure.Interfaces;
    using Database;

    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesDataHandler employeesDataHandler;
        private readonly IMapperService mapperService;

        public EmployeesService(IEmployeesDataHandler employeesDataHandler, IMapperService mapperService)
        {
            this.employeesDataHandler = employeesDataHandler;
            this.mapperService = mapperService;
        }

        public EmployeeModel Add(EmployeeModel еmployeeModel)
        {
            Employees employee = this.mapperService.Map<EmployeeModel, Employees>(еmployeeModel);
            employee.CreatedOn = DateTime.Now;
            employee.ModifiedOn = DateTime.Now;
            employee = this.employeesDataHandler.Add(employee);
            еmployeeModel = this.mapperService.Map<Employees, EmployeeModel>(employee);

            return еmployeeModel;
        }

        public void Delete(int id)
        {
            this.employeesDataHandler.Delete(id);
        }

        public EmployeeModel GetById(int id)
        {
            Employees employee = this.employeesDataHandler.GetById(id);
            EmployeeModel еmployeeModel = this.mapperService.Map<Employees, EmployeeModel>(employee);

            return еmployeeModel;
        }

        public EmployeeModel Update(EmployeeModel еmployeeModel)
        {
            Employees employee = this.mapperService.Map<EmployeeModel, Employees>(еmployeeModel);
            employee.ModifiedOn = DateTime.Now;
            employee = this.employeesDataHandler.Update(employee);
            еmployeeModel = this.mapperService.Map<Employees, EmployeeModel>(employee);

            return еmployeeModel;
        }
    }
}
