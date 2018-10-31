namespace STPGroup.MVCServices
{
    using System;
    using System.Collections.Generic;
    using STPGroup.MVCServices.Interfaces;
    using Services.ViewModels.MVCModels;
    using WebServices.Interfaces;
    using Services.Infrastructure.Interfaces;
    using Services.ViewModels.ApiModels;

    public class CompaniesMVCService : ICompaniesMVCService
    {
        private readonly ISTPGroupWebService stpGroupWebService;
        private readonly IMapperService mapperService;

        public CompaniesMVCService(ISTPGroupWebService stpGroupWebService, IMapperService mapperService)
        {
            this.stpGroupWebService = stpGroupWebService;
            this.mapperService = mapperService;
        }

        public IList<CompanyGridViewModel> GetCompanies()
        {
            IList<CompanyModel> companyModels = this.stpGroupWebService.GetAllCompanies();
            IList<CompanyGridViewModel> viewModels = this.mapperService.Map<IList<CompanyModel>, IList<CompanyGridViewModel>>(companyModels);

            return viewModels;
        }

        public void AddCompany(CompanyViewModel viewModel)
        {
            CompanyModel model = this.mapperService.Map<CompanyViewModel, CompanyModel>(viewModel);
            this.stpGroupWebService.AddCompany(model);
        }

        public CompanyViewModel GetEditCompany(int id)
        {
            CompanyModel companyModel = this.stpGroupWebService.GetCompanyById(id);
            CompanyViewModel viewModel = this.mapperService.Map<CompanyModel, CompanyViewModel>(companyModel);

            return viewModel;
        }

        public void SetEditCompany(CompanyViewModel viewModel)
        {
            CompanyModel model = this.mapperService.Map<CompanyViewModel, CompanyModel>(viewModel);
            this.stpGroupWebService.UpdateCompany(model);
        }

        public CompanyViewModel GetDeleteCompany(int id)
        {
            CompanyModel companyModel = this.stpGroupWebService.GetCompanyById(id);
            CompanyViewModel viewModel = this.mapperService.Map<CompanyModel, CompanyViewModel>(companyModel);

            return viewModel;
        }

        public void SetDeleteCompany(CompanyViewModel viewModel)
        {
            CompanyModel model = this.mapperService.Map<CompanyViewModel, CompanyModel>(viewModel);
            this.stpGroupWebService.DeleteCompany(model);
        }

        public CompanyDetailsViewModel GetDetails(int id)
        {
            CompanyModel companyModel = this.stpGroupWebService.GetCompanyById(id);
            CompanyDetailsViewModel viewModel = this.mapperService.Map<CompanyModel, CompanyDetailsViewModel>(companyModel);

            return viewModel;
        }
    }
}
