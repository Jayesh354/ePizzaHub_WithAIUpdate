# ePizzaHub API - Swagger/OpenAPI Documentation

## 🎯 Quick Start - Opening Swagger UI

### Method 1: Run from Visual Studio (Easiest)

1. **Set Startup Project**
   - Right-click on `ePizzaHub.API` project in Solution Explorer
   - Select "Set as Startup Project"

2. **Run the API**
   - Press `F5` or click the green "Start Debugging" button
   - Visual Studio will automatically open the API in your default browser

3. **Access Swagger UI**
   - The browser will navigate to: `https://localhost:7150/`
   - You'll see the Swagger UI interface with all API endpoints

### Method 2: Run from Command Line

```powershell
# Navigate to API project
cd C:\Users\Tanu_Dhanu\source\repos\ePizzaHub\ePizzaHub.API

# Run the application
dotnet run

# Swagger UI will be available at:
# https://localhost:7150/
```

### Method 3: Using dotnet watch (for development)

```powershell
cd C:\Users\Tanu_Dhanu\source\repos\ePizzaHub\ePizzaHub.API

# Run with hot reload - automatically refreshes on code changes
dotnet watch run

# Swagger UI will be available at:
# https://localhost:7150/
```

---

## 📖 What You'll See in Swagger UI

Once you access `https://localhost:7150/`, you'll see:

### Swagger Interface Components:

1. **API Information Header**
   - API Title: "ePizzaHub API"
   - Version: "v1"
   - Description: "RESTful API for ePizzaHub - Pizza Delivery Application"
   - Contact: Link to GitHub repository

2. **Endpoints List**
   - All available API controllers and routes
   - HTTP methods (GET, POST, PUT, DELETE, etc.)
   - Request/response schemas

3. **Interactive Testing**
   - Click "Try it out" on any endpoint
   - Enter parameters/body data
   - Click "Execute" to send the request
   - View response status, headers, and body

---

## 🔗 Swagger & OpenAPI URLs

### In Development Mode:

| Item | URL |
|------|-----|
| **Swagger UI** | `https://localhost:7150/` |
| **OpenAPI JSON** | `https://localhost:7150/swagger/v1/swagger.json` |
| **Swagger YAML** | `https://localhost:7150/swagger/v1/swagger.yaml` |

### Important Note:
- Swagger UI is **only enabled in Development mode**
- In Production (`appsettings.Development.json` not used), Swagger will be disabled for security

---

## 📝 Adding XML Documentation to Endpoints

To make your API documentation even better, add XML comments to your controller actions:

### Example - WeatherForecastController.cs

```csharp
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private static readonly string[] Summaries =
		[
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		];

		/// <summary>
		/// Get weather forecast for the next 5 days
		/// </summary>
		/// <remarks>
		/// This endpoint returns a 5-day weather forecast with random temperatures.
		/// </remarks>
		/// <returns>List of weather forecast data</returns>
		/// <response code="200">Successfully retrieved weather forecast</response>
		/// <response code="500">Internal server error</response>
		[HttpGet(Name = "GetWeatherForecast")]
		[ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]
		[ProducesResponseType(500)]
		public IEnumerable<WeatherForecast> Get()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
```

### Enable XML Comments in Project File

Add this to your `ePizzaHub.API.csproj`:

```xml
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

Then update `Program.cs` to include XML comments:

```csharp
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

	// Add XML comments to Swagger
	var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
	if (File.Exists(xmlPath))
	{
		options.IncludeXmlComments(xmlPath);
	}
});
```

---

## 🧪 Testing API Endpoints in Swagger

### Example: Testing WeatherForecast Endpoint

1. **Open Swagger UI** at `https://localhost:7150/`

2. **Find the Endpoint**
   - Look for "WeatherForecast" section
   - You'll see: `GET /WeatherForecast`

3. **Click "Try it out"**
   - Parameters will become editable (if any)

4. **Click "Execute"**
   - Request is sent to your API
   - Response appears below

5. **View Response**
   - Status Code: `200`
   - Response Body: JSON array of weather forecasts
   - Headers: Response headers information

---

## 🔐 Security Considerations

### Current Setup (Development)

✅ Swagger UI is enabled in Development mode
✅ Allows easy testing and documentation
✅ Automatically disabled in Production

### Production Environment

To disable Swagger in production:

The current configuration already handles this:

```csharp
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(...);
}
```

Only when `ASPNETCORE_ENVIRONMENT=Development` is set will Swagger be available.

---

## 📋 Downloading OpenAPI Specification

You can download the OpenAPI/Swagger specification for external use:

1. **Download JSON**
   - Visit: `https://localhost:7150/swagger/v1/swagger.json`
   - Save the JSON file for documentation or code generation

2. **Use in External Tools**
   - **Postman**: File → Import → Paste Raw Text (OpenAPI JSON)
   - **Insomnia**: Import → From URL or Raw Data
   - **SwaggerHub**: Create new API → Import OpenAPI 3.0

3. **Generate Client Code**
   - Use **NSwag** or **OpenAPI Generator** to generate client libraries
   - Supports C#, TypeScript, Python, Java, etc.

---

## 🚀 Next Steps

### 1. Add More Endpoints
Create new controllers and actions for your pizza delivery features:
- Menu controller
- Order controller
- User controller
- Delivery tracking controller

### 2. Add Authentication
Implement JWT authentication for secure endpoints

### 3. Document Your API
- Add XML comments to all endpoints
- Describe request/response schemas
- Add example values

### 4. Enable CORS (if needed)
If your UI needs to call the API from a different origin:

```csharp
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowUI", builder =>
		builder.WithOrigins("https://localhost:7049")
			   .AllowAnyMethod()
			   .AllowAnyHeader());
});

app.UseCors("AllowUI");
```

### 5. Add API Versioning
Support multiple versions of your API:

```bash
dotnet add package Asp.Versioning.Mvc.ApiExplorer
```

---

## 🔧 Troubleshooting

### Issue: "Swagger page is blank"
- **Solution**: Ensure the API is running (`F5` or `dotnet run`)
- Check browser console for errors (F12)

### Issue: "Cannot GET /swagger/ui"
- **Solution**: The URL should be just `/` or `/swagger/ui/` (note the trailing slash)
- Correct: `https://localhost:7150/`

### Issue: "Swagger doesn't appear when running"
- **Solution**: 
  - Verify `ASPNETCORE_ENVIRONMENT=Development`
  - Check `launchSettings.json` for profile configuration
  - Rebuild the project: `dotnet clean && dotnet build`

### Issue: "API endpoints not showing in Swagger"
- **Solution**: 
  - Ensure controllers have `[ApiController]` attribute
  - Add `[Route(...)]` attribute
  - Add HTTP method attributes: `[HttpGet]`, `[HttpPost]`, etc.

---

## 📚 References

- **Swashbuckle Documentation**: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
- **OpenAPI Specification**: https://spec.openapis.org/
- **ASP.NET Core API Documentation**: https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger

---

## 💡 Tips & Tricks

### Customize Swagger UI
You can customize the Swagger UI appearance:

```csharp
app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "ePizzaHub API v1");
	options.RoutePrefix = string.Empty;
	options.DocExpansion(DocExpansion.List); // Show all endpoints expanded
	options.DefaultModelsExpandDepth(2); // Show model depth
	options.ShowCommonExtensions(); // Show extensions
});
```

### Test Endpoints with Curl

```bash
# GET request
curl https://localhost:7150/WeatherForecast --insecure

# POST request with JSON body
curl -X POST https://localhost:7150/api/orders ^
  -H "Content-Type: application/json" ^
  -d "{\"item\":\"Pizza Margherita\"}" ^
  --insecure
```

---

**Setup Date**: January 2025
**API Version**: v1
**Framework**: .NET 10
**Documentation Tool**: Swashbuckle (Swagger)
