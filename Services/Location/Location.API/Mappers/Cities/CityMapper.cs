using Location.API.Models;
using Location.API.RequestModels.City;
using Location.API.ResponseModels.City;
using Riok.Mapperly.Abstractions;

namespace Location.API.Mappers.Cities;

[Mapper]
public partial class CityMapper
{
    //Get

    [MapProperty(nameof(City.Id), nameof(CityResponse.Id))] //Special Mapping
    public partial CityResponse CityToCityResponse(City city);
    public partial List<CityResponse> CitiesToCityListResponse(List<City> cities);

    //Create


    public partial City CreateCityRequestToCity(CreateCityRequest createCityRequest);
    public partial CreatedCityResponse CityToCreatedCityResponse(City city);

    //Update
    public partial UpdatedCityResponse CityToUpdatedCityResponse(City city);
    public partial City UpdateCityRequestToCity(UpdateCityRequest updateCityRequest);
}
