using eniyisinerede.webui.Extensions;
using eniyisinerede.webui.Handlers;
using eniyisinerede.webui.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyModel;
using Scrutor;
using SharedLibrary.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


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

builder.Services.Configure<ServiceSettings>(builder.Configuration.GetSection("ServiceSettings"));
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));

builder.Services.AddHttpClientServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IIdentitySharedService, IdentitySharedService>();

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddAccessTokenManagement();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Auth/SignIn";
        opt.ExpireTimeSpan = TimeSpan.FromDays(60); //Cookie life refresh token 60 gün olduğu için burada da 60 yaptık.
        opt.SlidingExpiration = true; //Her giriş yapıldığında cookie ömrü uzasın 
        opt.Cookie.Name = "webCookie";
    }); //Service'lerde bu kısımda jwt ile kullanıcı doğrulama yapıyorduk burada ise cookie ile.


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
