using Azure.Storage.Blobs;
using File.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddSingleton<IAzureBlobStorageService, AzureBlobStorageService>();
//builder.Services.AddSingleton<IFileService, FileService>();

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
