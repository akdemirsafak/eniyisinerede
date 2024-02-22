﻿using File.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(configs =>
    {
        configs.Authority = builder.Configuration["IdentityServerURL"];//Token dağıtmakla görevli api.Kritik! Bu kısmı appSettings.json da belirttik
        configs.Audience = "location_resource"; //IdentityServer'da bu isimle belirttik.
        configs.RequireHttpsMetadata = true; //Http kullansaydık false olarak ayarlayacaktık.
    });//Buradaki scheme name birden fazla token türü beklendiği durumlarda önemlidir.Bu ayrımın yapılması için Scheme Name kullanılır.



builder.Services.AddControllers(
    opt =>
    {
        opt.Filters.Add(new AuthorizeFilter());
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IAzureBlobStorageService, AzureBlobStorageService>();
builder.Services.AddSingleton<IFileService, FileService>();

//builder.Services.AddSingleton(new BlobServiceClient(builder.Configuration.GetValue<string>("AzureBlobStorageConnectionString")));

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
