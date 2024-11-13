using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ServerAPI1.Settings;

var builder = WebApplication.CreateBuilder(args);

// MongoDB settings fra appsettings.json
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

// Registrere MongoDB client
builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(
        sp.GetRequiredService<IOptions<MongoDBSettings>>().Value.ConnectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
