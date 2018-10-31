namespace STPGroup.WebAPI.App_Start.AutomapperProfiles
{
    using AutoMapper;
    using Database;
    using Services.ViewModels.ApiModels;

    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            this.CreateMap<Employees, EmployeeModel>()
                .ReverseMap();
        }
    }
}