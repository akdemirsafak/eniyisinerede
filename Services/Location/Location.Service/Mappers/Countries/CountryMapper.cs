using Location.API.Models;
using Location.API.RequestModels.Country;
using Location.API.ResponseModels.Country;
using Riok.Mapperly.Abstractions;

namespace Location.Service.Mappers.Countries;

[Mapper]
public partial class CountryMapper
{
    //Get

    // [MapProperty(nameof(Country.Id), nameof(CountryResponse.Id))] Special Mapping
    public partial CountryResponse CountryToCountryResponse(Country country);
    public partial List<CountryResponse> CountriesToCountryListResponse(List<Country> countries);

    //Create

    public partial Country CreateCountryRequestToCountry(CreateCountryRequest createCountryRequest);
    public partial CreatedCountryResponse CountryToCreatedCountryResponse(Country country);

    //Update

    public partial UpdatedCountryResponse CountryToUpdatedCountryResponse(Country country);
    public partial Country UpdateCountryRequestToCountry(UpdateCountryRequest updateCountryRequest);
}
