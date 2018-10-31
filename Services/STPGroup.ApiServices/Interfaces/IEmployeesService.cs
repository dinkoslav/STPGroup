using STPGroup.Services.ViewModels.ApiModels;

namespace STPGroup.ApiServices.Interfaces
{
    public interface IEmployeesService
    {
        EmployeeModel GetById(int id);

        EmployeeModel Add(EmployeeModel еmployeeModel);

        EmployeeModel Update(EmployeeModel еmployeeModel);

        void Delete(int id);
    }
}
