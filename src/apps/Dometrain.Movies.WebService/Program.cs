using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.InMemoryDataStore.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInMemoryDataStore();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async (AppDbContext appContext, IMoviesRepository moviesRepository, CancellationToken ct = default) =>
    {
        var allMovies = await moviesRepository.GetAllAsync(ct);
        var titanic = new Dometrain.Movies.Domain.Movie
        {
            Genres = new List<string> { "Drama", "Romance" },
            Title = "Titanic",
            YearOfRelease = 1997,
        };
        await moviesRepository.CreateAsync(titanic, ct);
        await appContext.SaveChangesAsync(ct);
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
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}