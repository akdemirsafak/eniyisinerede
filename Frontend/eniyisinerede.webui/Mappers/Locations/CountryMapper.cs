using AutoMapper;
using eniyisinerede.webui.ViewModels.Countries;

namespace eniyisinerede.webui.Mappers.Locations;

public class CountryMapper : Profile
{
    public CountryMapper()
    {
        CreateMap<CountryViewModel, CreateCountryViewModel>().ReverseMap();
        CreateMap<CountryViewModel, UpdateCountryViewModel>().ReverseMap();
    }
}
