using eniyisinerede.webui.Handlers;
using eniyisinerede.webui.Services;
using eniyisinerede.webui.Services.Interfaces;
using eniyisinerede.webui.Settings;

namespace eniyisinerede.webui.Extensions;

public static class HttpClientServiceExtension
{
    public static void AddHttpClientServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {

        var serviceApiSettings = configuration.GetSection("ServiceSettings").Get<ServiceSettings>();

        serviceCollection.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

        //IdentityService

        serviceCollection.AddHttpClient<IIdentityService, IdentityService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.IdentityBaseUri}");
        });


        //Place
        serviceCollection.AddHttpClient<IPlaceService, PlaceService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Location}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        //---Location

        serviceCollection.AddHttpClient<ICountryService, CountryService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Location}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        serviceCollection.AddHttpClient<ICityService, CityService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Location}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        serviceCollection.AddHttpClient<IDistrictService, DistrictService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Location}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        //---- Location End


        //ProductService
        serviceCollection.AddHttpClient<IProductService, ProductService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Product}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        //ReservationService
        serviceCollection.AddHttpClient<IReservationService, ReservationService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Reservation}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        //File Service
        serviceCollection.AddHttpClient<IFileService, FileService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.File}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        //Image Service
        serviceCollection.AddHttpClient<IImageService, ImageService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.File}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        //User Service
        serviceCollection.AddHttpClient<IUserService, UserService>(options =>
        {
            options.BaseAddress = new Uri($"{serviceApiSettings.IdentityBaseUri}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>(); //UserService çağırıldığında requestin header'ine token ekleyecek.

       
    }
}
