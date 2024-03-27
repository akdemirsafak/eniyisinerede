using AutoMapper;
using eniyisinerede.webui.ViewModels.Places;
namespace eniyisinerede.webui.Mappers.Places;

public class PlaceMapper : Profile
{
    public PlaceMapper()
    {
        CreateMap<PlaceViewModel, CreatePlaceViewModel>();
        CreateMap<PlaceViewModel, UpdatePlaceViewModel>();
    }
}
