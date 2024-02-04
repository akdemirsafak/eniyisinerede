using eniyisinerede.API.Repository;
using eniyisinerede.API.Service;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

//builder.Services.Scan(scan => scan.FromAssemblyOf<CountryRepository>()
//.AddClasses()
//.AsImplementedInterfaces()
//.WithScopedLifetime());

//builder.Services.Scan(scan => scan.FromAssemblyOf<CountryService>()
//    .AddClasses()
//       .AsImplementedInterfaces()
//          .WithScopedLifetime());

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();


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
