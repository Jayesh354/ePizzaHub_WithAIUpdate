var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ePizzaHub API",
        Version = "v1",
        Description = "RESTful API for ePizzaHub - Pizza Delivery Application",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "ePizzaHub Development Team",
            Url = new Uri("https://github.com/Jayesh354/ePizzaHub_WithAIUpdate")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger middleware
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ePizzaHub API v1");
        options.RoutePrefix = string.Empty; // Swagger UI at root
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
