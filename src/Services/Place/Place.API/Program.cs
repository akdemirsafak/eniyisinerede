using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Place.API.Mongo;
using Place.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(configs =>
    {
        configs.Authority = builder.Configuration["IdentityServerURL"];//Token dağıtmakla görevli api.Kritik! Bu kısmı appSettings.json da belirttik
        configs.Audience = "place_resource"; //IdentityServer'da bu isimle belirttik.
        configs.RequireHttpsMetadata = true; //Http kullansaydık false olarak ayarlayacaktık.
    });//Buradaki scheme name birden fazla token türü beklendiği durumlarda önemlidir.Bu ayrımın yapılması için Scheme Name kullanılır.




//Options Pattern Implementation
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //Datalari okuyarak DatabaseSettings class'ini doldurdu
builder.Services.AddSingleton<IDatabaseSettings>(serviceProvider =>
{
    return serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});//IDatabaseSettings bir ctor'da gecildiginde bize DatabaseSettings'de tanimli degerler gelecek.

builder.Services.AddScoped<IPlaceService, PlaceService>();


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter()); //Tüm endpoint'leri authorize hale getirmiş olduk.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
