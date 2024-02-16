using eniyisinerede.webui.Services;
using eniyisinerede.webui.Services.Interfaces;

namespace eniyisinerede.webui.Extensions;

public static class HttpClientServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient<IPlaceService, PlaceService>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:5010/api/");
        });

        serviceCollection.AddHttpClient<IProductService, ProductService>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:5012/api/");
        });

        serviceCollection.AddHttpClient<IReservationService, ReservationService>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:5013/api/");
        });

        serviceCollection.AddHttpClient<ICountryService, CountryService>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:5011/api/");
        });

        serviceCollection.AddHttpClient<ICityService, CityService>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:5011/api/");
        });

        serviceCollection.AddHttpClient<IDistrictService, DistrictService>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:5011/api/");
        });
        serviceCollection.AddHttpClient<IFileService, FileService>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:5014/api/");
        });
        serviceCollection.AddHttpClient<IImageService, ImageService>(options =>
        {
            options.BaseAddress = new Uri("https://localhost:5014/api/");
        });
    }
}
