namespace STPGroup.MVC.App_Start.AutomapperProfiles
{
    using AutoMapper;
    using Services.ViewModels.ApiModels;
    using Services.ViewModels.MVCModels;

    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            this.CreateMap<EmployeeModel, EmployeeViewModel>()
                .ReverseMap();
        }
    }
}