using AutoMapper;
using TestFluentValidation.Application.Models.Entities;
using TestFluentValidation.Domain.Entities;

namespace TestFluentValidation.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
       CreateMap<Country, CountryVM>().ReverseMap();
        CreateMap<State,StateVM>().ReverseMap();
        CreateMap<City,CityVM>().ReverseMap();
        CreateMap<Student,StudentVM>().ReverseMap();
       

    }
}
