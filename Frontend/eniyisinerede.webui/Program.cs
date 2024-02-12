using eniyisinerede.webui.Services;
using eniyisinerede.webui.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();

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
