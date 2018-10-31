namespace STPGroup.WebAPI.Controllers
{
    using ApiServices.Interfaces;
    using Services.ViewModels.ApiModels;
    using System.Web.Http;

    public class EmployeesController : ApiController
    {
        private readonly IEmployeesService employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }

        // GET api/employees/id
        [HttpGet]
        [Route("api/employees/{id}")]
        public IHttpActionResult Get(int id)
        {
            EmployeeModel employeeModel = this.employeesService.GetById(id);

            if (employeeModel == null)
            {
                return this.NotFound();
            }

            return this.Ok<EmployeeModel>(employeeModel);
        }

        // POST api/employees/add
        [HttpPost]
        [Route("api/employees/add")]
        public IHttpActionResult Add(EmployeeModel employeeModel)
        {
            employeeModel = this.employeesService.Add(employeeModel);

            return this.Ok(employeeModel);
        }

        // POST api/employees/update
        [HttpPost]
        [Route("api/employees/update")]
        public IHttpActionResult Update(EmployeeModel employeeModel)
        {
            employeeModel = this.employeesService.Update(employeeModel);

            return this.Ok<EmployeeModel>(employeeModel);
        }

        // POST api/employees/delete
        [HttpPost]
        [Route("api/employees/delete")]
        public IHttpActionResult Delete(EmployeeModel employeeModel)
        {
            this.employeesService.Delete(employeeModel.Id);

            return this.Ok();
        }
    }
}