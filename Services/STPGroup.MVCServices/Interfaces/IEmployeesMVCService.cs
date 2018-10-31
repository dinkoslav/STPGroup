using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STPGroup.Services.ViewModels.MVCModels;

namespace STPGroup.MVCServices.Interfaces
{
    public interface IEmployeesMVCService
    {
        bool SalaryIsValid(EmployeeViewModel viewModel);

        void AddEmployee(EmployeeViewModel viewModel);

        void SetDeleteEmployee(EmployeeViewModel viewModel);

        EmployeeViewModel GetDeleteEmployee(int id);

        void SetEditEmployee(EmployeeViewModel viewModel);

        EmployeeViewModel GetEditEmployee(int id);
    }
}
