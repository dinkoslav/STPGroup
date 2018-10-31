namespace STPGroup.ApiServices
{
    using Data.DataHandlers.Interfaces;
    using Database;
    using Services.Infrastructure.Interfaces;
    using Services.ViewModels.ApiModels;
    using STPGroup.ApiServices.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CompaniesService : ICompaniesService
    {
        private readonly ICompaniesDataHandler companiesDataHandler;
        private readonly IMapperService mapperService;

        public CompaniesService(ICompaniesDataHandler companiesDataHandler, IMapperService mapperService)
        {
            this.companiesDataHandler = companiesDataHandler;
            this.mapperService = mapperService;
        }

        public CompanyModel Add(CompanyModel companyModel)
        {
            Companies company = this.mapperService.Map<CompanyModel, Companies>(companyModel);
            company.CreatedOn = DateTime.Now;
            company.ModifiedOn = DateTime.Now;
            company = this.companiesDataHandler.Add(company);
            companyModel = this.mapperService.Map<Companies, CompanyModel>(company);

            return companyModel;
        }

        public IEnumerable<CompanyModel> All()
        {
            IList<Companies> companies = this.companiesDataHandler.All().ToList();
            IList<CompanyModel> companiesModels = this.mapperService.Map<IList<Companies>, IList<CompanyModel>>(companies);

            return companiesModels;
        }

        public void Delete(int id)
        {
            this.companiesDataHandler.Delete(id);
        }

        public CompanyModel GetById(int id)
        {
            Companies company = this.companiesDataHandler.GetById(id);
            CompanyModel companyModel = this.mapperService.Map<Companies, CompanyModel>(company);

            return companyModel;
        }

        public CompanyModel Update(CompanyModel companyModel)
        {
            Companies company = this.mapperService.Map<CompanyModel, Companies>(companyModel);
            company.ModifiedOn = DateTime.Now;
            company = this.companiesDataHandler.Update(company);
            companyModel = this.mapperService.Map<Companies, CompanyModel>(company);

            return companyModel;
        }
    }
}
