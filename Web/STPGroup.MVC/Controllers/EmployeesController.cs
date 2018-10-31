using STPGroup.MVCServices.Interfaces;
using STPGroup.Services.Infrastructure.Enums;
using STPGroup.Services.ViewModels.MVCModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STPGroup.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesMVCService employeesMVCService;

        public EmployeesController(IEmployeesMVCService employeesMVCService)
        {
            this.employeesMVCService = employeesMVCService;
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            EmployeeViewModel viewModel = new EmployeeViewModel { CompanyId = id, StartingDate = DateTime.Now, ExperienceLevelId = (int)ExperienceLevelType.A };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(EmployeeViewModel viewModel)
        {
            if (!this.employeesMVCService.SalaryIsValid(viewModel))
            {
                this.ModelState.AddModelError("Salary", "Not between company limits!!!");
            }

            if (this.ModelState.IsValid)
            {
                this.employeesMVCService.AddEmployee(viewModel);

                return this.RedirectToAction("Details", "Companies", new { id = viewModel.CompanyId });
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeViewModel viewModel = this.employeesMVCService.GetEditEmployee(id);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel viewModel)
        {
            if (!this.employeesMVCService.SalaryIsValid(viewModel))
            {
                this.ModelState.AddModelError("Salary", "Not between company limits!!!");
            }

            if (this.ModelState.IsValid)
            {
                this.employeesMVCService.SetEditEmployee(viewModel);

                return this.RedirectToAction("Details", "Companies", new { id = viewModel.CompanyId });
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            EmployeeViewModel viewModel = this.employeesMVCService.GetDeleteEmployee(id);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(EmployeeViewModel viewModel)
        {
            this.employeesMVCService.SetDeleteEmployee(viewModel);

            return this.RedirectToAction("Details", "Companies", new { id = viewModel.CompanyId });
        }
    }
}