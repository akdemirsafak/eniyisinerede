using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Product.API.DbContexts;
using Product.API.Repositories;
using Product.API.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
//opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter()); //Tüm endpoint'leri authorize hale getirmiş olduk.
//}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(configs =>
    {
        configs.Authority = builder.Configuration["IdentityServerURL"];//Token dağıtmakla görevli api.Kritik! Bu kısmı appSettings.json da belirttik
        configs.Audience = "product_resource"; //IdentityServer'da bu isimle belirttik.
        configs.RequireHttpsMetadata = true; //Http kullansaydık false olarak ayarlayacaktık.
    });//Buradaki scheme name birden fazla token türü beklendiği durumlarda önemlidir.Bu ayrımın yapılması için Scheme Name kullanılır.


builder.Services.AddDbContext<ApiDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    option => { option.MigrationsAssembly(Assembly.GetAssembly(typeof(ApiDbContext))!.GetName().Name); })
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
