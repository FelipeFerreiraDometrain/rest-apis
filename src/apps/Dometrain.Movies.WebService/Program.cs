
namespace Dometrain.Movies.WebService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
        
            // Add services to the container.
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();
            builder.Services.AddApplicationServices();
            builder.Services.AddControllers();

            var app = builder.Build();
            // temporary
            app.Use(async (context, next) =>
            {
                var loggingFactory = context.RequestServices.GetRequiredService<ILoggerFactory>();
                var logger = loggingFactory.CreateLogger("middleware");
                var endpoint = context.GetEndpoint();
                logger.LogInformation(endpoint?.DisplayName);
                await next();
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();
            app.MapControllers();
            await app.RunAsync();
    
        }
    }
}