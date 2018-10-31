using Moq;
using NUnit.Framework;
using STPGroup.MVCServices;
using STPGroup.MVCServices.Interfaces;
using STPGroup.Services.Infrastructure;
using STPGroup.Services.Infrastructure.Interfaces;
using STPGroup.Services.ViewModels.ApiModels;
using STPGroup.Services.ViewModels.MVCModels;
using STPGroup.WebServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STPGroup.Tests
{
    [TestFixture]
    public class EmployeesMVCServiceTestClass
    {
        private IEmployeesMVCService employeesMVCService;
        private Mock<ISTPGroupWebService> mockSTPGroupWebService;

        [SetUp]
        public void Init()
        {
            this.mockSTPGroupWebService = new Mock<ISTPGroupWebService>();
            this.mockSTPGroupWebService.Setup(x => x.GetCompanyById(It.IsAny<int>()))
                .Returns(new CompanyModel()
                {
                    Name = "Name",
                    Address = "Address",
                    SalaryMin = 1000,
                    SalaryMax = 2000
                });
            this.employeesMVCService = new EmployeesMVCService(this.mockSTPGroupWebService.Object, new MapperService());
        }

        [Test]
        public void GetSalaryIsValid()
        {
            bool result = this.employeesMVCService.SalaryIsValid(new EmployeeViewModel
            {
                CompanyId = 1,
                Salary = 1100
            });

            Assert.IsTrue(result);
        }

        [Test]
        public void GetSalaryIsNotValid()
        {
            bool result = this.employeesMVCService.SalaryIsValid(new EmployeeViewModel
            {
                CompanyId = 1,
                Salary = 100
            });

            Assert.IsFalse(result);
        }
    }
}
