namespace STPGroup.WebAPI.App_Start.AutomapperProfiles
{
    using AutoMapper;
    using Database;
    using Services.ViewModels.ApiModels;

    public class CompaniesProfile : Profile
    {
        public CompaniesProfile()
        {
            this.CreateMap<Companies, CompanyModel>()
                .ForMember(sd => sd.Employees, opt => opt.MapFrom(src => src.Employees))
                .ReverseMap();
        }
    }
}