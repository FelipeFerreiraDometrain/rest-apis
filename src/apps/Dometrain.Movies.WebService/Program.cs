using Dometrain.Movies.ApplicationAbstractions;
using Dometrain.Movies.InMemoryDataStore.Context;
using Dometrain.Movies.WebService.Contracts.Response;
using Microsoft.AspNetCore.Http.HttpResults;
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

app.MapGet("/movies", async (IMoviesRepository moviesRepository, CancellationToken ct = default) =>
    {
        var allMovies = await moviesRepository.GetAllAsync(ct);
        return Results.Ok(new MoviesResponse { 
            Items = allMovies.Select(movie => new MovieResponse
            {
                Genres = movie.Genres,
                Id = movie.Id,
                Title = movie.Title,
                YearOfRelease = movie.YearOfRelease,
            }
        )});
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}