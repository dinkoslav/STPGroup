namespace STPGroup.MVC.Controllers
{
    using System.Web.Mvc;
    using STPGroup.MVCServices.Interfaces;
    using Services.ViewModels.MVCModels;
    using System.Collections.Generic;

    public class CompaniesController : Controller
    {
        private readonly ICompaniesMVCService companiesMVCService;

        public CompaniesController(ICompaniesMVCService companiesMVCService)
        {
            this.companiesMVCService = companiesMVCService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IList<CompanyGridViewModel> viewModel = this.companiesMVCService.GetCompanies();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            CompanyViewModel viewModel = new CompanyViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(CompanyViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.companiesMVCService.AddCompany(viewModel);

                return this.RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CompanyViewModel viewModel = this.companiesMVCService.GetEditCompany(id);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(CompanyViewModel viewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.companiesMVCService.SetEditCompany(viewModel);

                return this.RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            CompanyViewModel viewModel = this.companiesMVCService.GetDeleteCompany(id);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(CompanyViewModel viewModel)
        {
            this.companiesMVCService.SetDeleteCompany(viewModel);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            CompanyDetailsViewModel viewModel = this.companiesMVCService.GetDetails(id);

            return View(viewModel);
        }
    }
}