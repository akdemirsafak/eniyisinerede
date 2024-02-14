using AutoMapper;
using eniyisinerede.webui.ViewModels.Cities;

namespace eniyisinerede.webui.Mappers.Locations;

public class CityMapper : Profile
{
    public CityMapper()
    {
        CreateMap<CityViewModel, CreateCityViewModel>().ReverseMap();
        CreateMap<CityViewModel, UpdateCityViewModel>().ReverseMap();
    }
}
