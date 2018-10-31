namespace STPGroup.ApiServices.Interfaces
{
    using STPGroup.Services.ViewModels.ApiModels;
    using System.Collections.Generic;

    public interface ICompaniesService
    {
        IEnumerable<CompanyModel> All();

        CompanyModel GetById(int id);

        CompanyModel Add(CompanyModel companyModel);

        CompanyModel Update(CompanyModel companyModel);

        void Delete(int id);
    }
}
