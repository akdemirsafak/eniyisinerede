using eniyisinerede.API.Models;
using eniyisinerede.API.RequestModels;
using eniyisinerede.API.ResponseModels;
using Riok.Mapperly.Abstractions;

namespace eniyisinerede.API.Mappers.Countries;

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
