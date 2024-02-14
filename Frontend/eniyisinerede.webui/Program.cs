using eniyisinerede.webui.Services;
using eniyisinerede.webui.Services.Interfaces;
using Microsoft.Extensions.DependencyModel;
using Scrutor;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpContextAccessor();

var assemblies = DependencyContext.Default.RuntimeLibraries
    .Where(library => library.Name.StartsWith("eniyisinerede.webui"))
    .Select(library => Assembly.Load(new AssemblyName(library.Name)))
    .ToList();

builder.Services.Scan(scan => scan.FromAssemblies(assemblies)
                          .AddClasses()
                          .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                          .AsMatchingInterface()
                          .WithScopedLifetime());

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddHttpClient<IPlaceService, PlaceService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:5010/api/");
});

builder.Services.AddHttpClient<IProductService, ProductService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:5012/api/");
});

builder.Services.AddHttpClient<IReservationService, ReservationService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:5013/api/");
});

builder.Services.AddHttpClient<ICountryService, CountryService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:5011/api/");
});

builder.Services.AddHttpClient<ICityService, CityService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:5011/api/");
});

builder.Services.AddHttpClient<IDistrictService, DistrictService>(options =>
{
    options.BaseAddress = new Uri("https://localhost:5011/api/");
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
