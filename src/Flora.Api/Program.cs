using Microsoft.EntityFrameworkCore;
using Flora.Api.Data;
using Flora.Api.Features.Species;
using Flora.Api.Features.Taxonomy;
using Flora.Api.Features.Distribution;
using Flora.Api.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<FloraDbContext>(options =>
    options.UseNpgsql(connectionString, o => o.UseNetTopologySuite()));

// Add MediatR for CQRS pattern
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add Localization service
builder.Services.AddSingleton<ILocalizationService, LocalizationService>();

// Add CORS for Vue.js frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowVueApp");

// Map feature endpoints
app.MapSpeciesEndpoints();
app.MapTaxonomyEndpoints();
app.MapDistributionEndpoints();

// Keep the sample weather forecast endpoint for now
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
