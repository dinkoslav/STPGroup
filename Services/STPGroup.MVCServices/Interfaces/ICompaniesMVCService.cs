namespace STPGroup.MVCServices.Interfaces
{
    using STPGroup.Services.ViewModels.MVCModels;
    using System.Collections.Generic;

    public interface ICompaniesMVCService
    {
        IList<CompanyGridViewModel> GetCompanies();

        void AddCompany(CompanyViewModel viewModel);

        CompanyViewModel GetEditCompany(int id);

        void SetEditCompany(CompanyViewModel viewModel);

        CompanyViewModel GetDeleteCompany(int id);

        void SetDeleteCompany(CompanyViewModel viewModel);

        CompanyDetailsViewModel GetDetails(int id);
    }
}
