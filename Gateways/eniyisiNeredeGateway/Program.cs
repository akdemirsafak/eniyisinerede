using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication()
    .AddJwtBearer("GatewayAuthenticationScheme", opt => //Bu scheme name config dosyasında hangi root'a eklersek o token ile korunacak.
    {
        opt.Authority = builder.Configuration["IdentityServerURL"];
        opt.Audience = "gateway_resource";
        opt.RequireHttpsMetadata = false;
    });


builder.Services
    .AddOcelot();


builder.Services.AddHttpContextAccessor();

builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName}.json")

    .AddEnvironmentVariables();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await app.UseOcelot();
app.Run();
