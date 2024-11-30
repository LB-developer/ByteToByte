using ByteToByte.Models;
using ByteToByte.Services;
using MongoDB.Driver.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.json", optional:false, reloadOnChange:true)
    .AddUserSecrets<Program>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// open mongoDB connection
builder.Services.Configure<MongoDbSettings>(options =>
{
    builder.Configuration.GetSection("ByteMongoDB").Bind(options);
    
    var connectionString = builder.Configuration["ByteToByte:ConnectionURI"];
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new Exception("Connection string not found. Ensure User Secrets are set correctly.");
    }
    
    options.ConnectionURI = connectionString;
});

builder.Services.AddSingleton<MongoDbService>();

// Add CORS for frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// swagger config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// build app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();