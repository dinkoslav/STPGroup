namespace STPGroup.MVC.App_Start.AutomapperProfiles
{
    using AutoMapper;
    using Services.ViewModels.ApiModels;
    using Services.ViewModels.MVCModels;

    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            this.CreateMap<CompanyModel, CompanyGridViewModel>()
                .ForMember(sd => sd.EmployeesCount, opt => opt.MapFrom(src => src.Employees.Count));

            this.CreateMap<CompanyModel, CompanyDetailsViewModel>()
                .ForMember(sd => sd.Employees, opt => opt.MapFrom(src => src.Employees));

            this.CreateMap<CompanyViewModel, CompanyModel>()
                .ReverseMap();
        }
    }
}