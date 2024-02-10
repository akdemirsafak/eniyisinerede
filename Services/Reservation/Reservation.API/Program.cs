using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Reservation.API.DbContext;
using Reservation.API.Interceptors;
using Reservation.API.Repositories;
using Reservation.API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<AuditableEntitiesInterceptor>();

builder.Services.AddDbContext<ApiDbContext>((sp, opt) =>
{
    var interceptor=sp.GetService<AuditableEntitiesInterceptor>()!;

    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    option => { option.MigrationsAssembly(Assembly.GetAssembly(typeof(ApiDbContext))!.GetName().Name); })
        .AddInterceptors(interceptor);
});

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());



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
