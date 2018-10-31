namespace STPGroup.WebAPI.Controllers
{
    using ApiServices.Interfaces;
    using Services.ViewModels.ApiModels;
    using System.Collections.Generic;
    using System.Web.Http;

    public class CompaniesController : ApiController
    {
        private readonly ICompaniesService companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            this.companiesService = companiesService;
        }

        // GET api/companies
        [HttpGet]
        [Route("api/companies")]
        public IHttpActionResult Get()
        {
            return this.Ok<IEnumerable<CompanyModel>>(this.companiesService.All());
        }

        // GET api/companies/id
        [HttpGet]
        [Route("api/companies/{id}")]
        public IHttpActionResult Get(int id)
        {
            CompanyModel companyModel = this.companiesService.GetById(id);

            if (companyModel == null)
            {
                return this.NotFound();
            }

            return this.Ok<CompanyModel>(companyModel);
        }

        // POST api/companies/add
        [HttpPost]
        [Route("api/companies/add")]
        public IHttpActionResult Add(CompanyModel companyModel)
        {
            companyModel = this.companiesService.Add(companyModel);

            return this.Ok(companyModel);
        }

        // POST api/companies/update
        [HttpPost]
        [Route("api/companies/update")]
        public IHttpActionResult Update(CompanyModel companyModel)
        {
            companyModel = this.companiesService.Update(companyModel);

            return this.Ok<CompanyModel>(companyModel);
        }

        // POST api/companies/delete
        [HttpPost]
        [Route("api/companies/delete")]
        public IHttpActionResult Delete(CompanyModel companyModel)
        {
            this.companiesService.Delete(companyModel.Id);

            return this.Ok();
        }
    }
}