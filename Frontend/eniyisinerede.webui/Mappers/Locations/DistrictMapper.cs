using AutoMapper;
using eniyisinerede.webui.ViewModels.Districts;

namespace eniyisinerede.webui.Mappers.Locations;

public class DistrictMapper : Profile
{
    public DistrictMapper()
    {
        CreateMap<CreateDistrictViewModel, DistrictViewModel>().ReverseMap();
        CreateMap<UpdateDistrictViewModel, DistrictViewModel>().ReverseMap();
    }
}
