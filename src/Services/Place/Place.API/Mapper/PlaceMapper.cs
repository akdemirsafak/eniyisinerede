using AutoMapper;
using Place.API.Models;

namespace Place.API.Mapper;

public class PlaceMapper:Profile
{
    public PlaceMapper()
    {
        CreateMap<PlaceResponse, Place.API.Models.Place>().ReverseMap();

        CreateMap<CreatePlaceRequest, Place.API.Models.Place>().ReverseMap();

        CreateMap<UpdatePlaceRequest, Place.API.Models.Place>().ReverseMap();
    }
}
