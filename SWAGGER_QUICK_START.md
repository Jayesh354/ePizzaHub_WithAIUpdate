# 🚀 Quick Reference - Opening Swagger for ePizzaHub API

## ⚡ Fastest Way (3 Steps)

### 1️⃣ Open the Solution
- Open `C:\Users\Tanu_Dhanu\source\repos\ePizzaHub\ePizzaHub.slnx` in Visual Studio

### 2️⃣ Run the API
- **Option A (Visual Studio):** 
  - Right-click `ePizzaHub.API` → Set as Startup Project
  - Press `F5`

- **Option B (Terminal):**
  ```powershell
  cd ePizzaHub.API
  dotnet run
  ```

### 3️⃣ Open Browser
- Navigate to: **`https://localhost:7150/`**

✅ **You're done!** Swagger UI is now open with all API endpoints.

---

## 📍 Important URLs

| Item | URL |
|------|-----|
| **Swagger UI (Interactive)** | `https://localhost:7150/` |
| **OpenAPI JSON Spec** | `https://localhost:7150/swagger/v1/swagger.json` |
| **API Base URL** | `https://localhost:7150` |

---

## 🎯 What to Do in Swagger

### Testing an Endpoint (e.g., WeatherForecast)

1. Find "WeatherForecast" section in Swagger
2. Click on "GET /WeatherForecast"
3. Click "Try it out" button
4. Click "Execute"
5. See the response below

### Understanding the Response

```json
[
  {
	"date": "2025-01-24",
	"temperatureC": 12,
	"temperatureF": 53,
	"summary": "Mild"
  },
  ...
]
```

---

## 🛑 If Swagger Doesn't Open

### Issue: "This site can't be reached"
- ✅ Make sure API is running (you should see console output)
- ✅ Check the port: should be `7150` (or check `launchSettings.json`)

### Issue: "Swagger page is blank"
- ✅ Clear browser cache: `Ctrl + Shift + Delete`
- ✅ Try incognito mode: `Ctrl + Shift + N`

### Issue: No endpoints showing
- ✅ Make sure controllers have `[ApiController]` attribute
- ✅ Make sure methods have HTTP attributes like `[HttpGet]`
- ✅ Rebuild: `dotnet clean && dotnet build`

---

## 📝 Project Configuration

### Enabled in Development
- Swagger is **only active** when `ASPNETCORE_ENVIRONMENT=Development`
- Check `Properties/launchSettings.json` to see current environment

### Disabled in Production
- For security, Swagger is automatically disabled in non-Development environments

---

## 💡 Pro Tips

### 1. Download OpenAPI Spec
- Go to: `https://localhost:7150/swagger/v1/swagger.json`
- Right-click → Save As
- Use in Postman, Insomnia, or code generators

### 2. Test with cURL
```powershell
# Windows PowerShell
$response = Invoke-WebRequest -Uri "https://localhost:7150/WeatherForecast" `
  -SkipCertificateCheck
$response.Content | ConvertFrom-Json | Format-Table
```

### 3. See Full Documentation
- Read [SWAGGER_SETUP.md](SWAGGER_SETUP.md) for advanced features
- Learn how to add XML documentation to your endpoints

---

## 📚 Next Steps

- ✅ Test existing endpoints
- 📝 Add XML comments to controllers for better documentation
- 🔗 Create new API endpoints for pizza, orders, users
- 🔐 Add authentication (JWT)
- 🌐 Enable CORS for UI to communicate with API

---

**Last Updated:** January 2025  
**Framework:** .NET 10  
**Documentation Tool:** Swashbuckle (Swagger)
