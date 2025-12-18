using Microsoft.EntityFrameworkCore;
using MediatR;
using Flora.Api.Data;
using Flora.Api.Features.Species;
using Flora.Api.Features.Taxonomy;
using Flora.Api.Features.Distribution;
using Flora.Api.Localization;
using Serilog;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using Flora.Api.Features.Species.Create;
using Flora.Api.Features.Species.Update;
using Flora.Api.Features.Species.Delete;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog from configuration and console sink
builder.Host.UseSerilog((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console());

// Register validators explicitly
builder.Services.AddScoped<IValidator<CreateSpeciesCommand>, CreateSpeciesCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateSpeciesCommand>, UpdateSpeciesCommandValidator>();
builder.Services.AddScoped<IValidator<DeleteSpeciesCommand>, DeleteSpeciesCommandValidator>();

// Add health checks (basic). Add NPGSQL check package for DB health in future.
builder.Services.AddHealthChecks();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<FloraDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add MediatR for CQRS pattern
builder.Services.AddMediatR(typeof(Program));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add Localization service
builder.Services.AddSingleton<ILocalizationService, LocalizationService>();

// Add CORS for Vue.js frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
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

// Global exception handling (JSON responses)
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerPathFeature>();
        var ex = feature?.Error;
        context.Response.ContentType = "application/json";
        if (ex is FluentValidation.ValidationException)
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        else
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var result = JsonSerializer.Serialize(new { error = ex?.Message });
        await context.Response.WriteAsync(result);
    });
});

// Health endpoint
app.MapHealthChecks("/health");

// Map feature endpoints
app.MapSpeciesEndpoints();
app.MapTaxonomyEndpoints();
app.MapDistributionEndpoints();

app.Run();
