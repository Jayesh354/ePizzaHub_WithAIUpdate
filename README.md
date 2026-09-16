# ePizzaHub

A modern, cloud-ready pizza delivery application built with .NET 10, featuring a distributed architecture with separate UI and API layers.

## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Architecture](#architecture)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Development](#development)
- [Building and Deployment](#building-and-deployment)
- [Changelog](#changelog)

## 🎯 Project Overview

**ePizzaHub** is an AI-enhanced pizza delivery platform that aims to modernize the food delivery experience. The project is designed with a clean, scalable architecture that separates concerns between the presentation layer and the backend API.

**Key Features:**
- Modern ASP.NET Core web interface for user interaction
- RESTful API backend for handling business logic
- Support for pizza ordering and delivery management
- Built with .NET 10 for high performance and latest framework features
- AI integration capabilities for enhanced user experience

**Repository:** https://github.com/Jayesh354/ePizzaHub_WithAIUpdate

**Current Branch:** `jarohit/main-dev`

## 🏗️ Architecture

The ePizzaHub project follows a **two-tier microservices architecture** with clear separation of concerns:

```
┌─────────────────────────────────────────────────────────────┐
│                        Client Browser                        │
└────────────────────────────┬────────────────────────────────┘
							 │
							 ▼
┌─────────────────────────────────────────────────────────────┐
│                    ePizzaHub.UI Layer                        │
│                (ASP.NET Core MVC / Static Assets)            │
│  - HomeController - Views - Shared Layouts - Static Content  │
│              Runs on: https://localhost:7049                 │
└────────────────────────────┬────────────────────────────────┘
							 │
							 ▼
┌─────────────────────────────────────────────────────────────┐
│                   ePizzaHub.API Layer                        │
│               (RESTful API - Core Business Logic)            │
│    - Controllers - Data Models - Services - Business Logic   │
│              Runs on: https://localhost:7150                 │
└─────────────────────────────────────────────────────────────┘
							 │
							 ▼
┌─────────────────────────────────────────────────────────────┐
│                  External Services/Database                  │
│          (To be configured for production use)               │
└─────────────────────────────────────────────────────────────┘
```

### Layer Descriptions

#### 1. **ePizzaHub.UI** - Presentation Layer
- **Type:** ASP.NET Core MVC Application
- **Port:** `https://localhost:7049`
- **Responsibilities:**
  - User interface and user interaction
  - Server-side rendering with Razor views
  - Static asset management (CSS, JavaScript, images)
  - Client-side form validation
  - Routing and navigation
- **Key Components:**
  - `Controllers/HomeController.cs` - Main UI controller
  - `Views/` - Razor view templates
  - `wwwroot/` - Static assets (Bootstrap, jQuery, CSS, JS)

#### 2. **ePizzaHub.API** - Backend API Layer
- **Type:** ASP.NET Core REST API
- **Port:** `https://localhost:7150`
- **Responsibilities:**
  - Business logic implementation
  - Data processing and management
  - API endpoint exposure
  - Request validation and processing
  - Response serialization
- **Key Components:**
  - `Controllers/` - API controllers and endpoints
  - `Models/` - Data models and entity definitions
  - `appsettings.json` - Configuration

### Communication Pattern
- **UI → API:** The UI layer communicates with the API layer via HTTP REST calls
- **API → External Services:** The API layer can interact with databases and external services
- **Response Format:** JSON (standard REST API convention)

## 💻 Technology Stack

| Layer | Technology | Version | Purpose |
|-------|-----------|---------|---------|
| **Runtime** | .NET | 10.0 | Cross-platform runtime |
| **Framework** | ASP.NET Core | Latest | Web framework |
| **UI Framework** | Bootstrap | Latest | Responsive CSS framework |
| **Scripting** | jQuery | Latest | DOM manipulation |
| **Validation** | jQuery Validation | Latest | Client-side form validation |
| **API Format** | REST/JSON | N/A | API communication |
| **Package Manager** | NuGet | Latest | Dependency management |

### Dependencies

**ePizzaHub.UI:**
- `Microsoft.OpenApi` v3.10.2

**ePizzaHub.API:**
- `Microsoft.OpenApi` v3.10.2

### Language Features
- **C# Version:** Latest (.NET 10)
- **Nullable Reference Types:** Enabled
- **Implicit Usings:** Enabled (using statement simplification)

## 📁 Project Structure

```
ePizzaHub/
├── README.md                           # This file
├── ePizzaHub.slnx                      # Solution file
├── .gitignore                          # Git ignore rules
│
├── ePizzaHub.UI/                       # Presentation Layer
│   ├── ePizzaHub.UI.csproj            # Project file
│   ├── Program.cs                      # Application startup configuration
│   ├── Controllers/
│   │   └── HomeController.cs          # Main UI controller
│   ├── Models/
│   │   └── ErrorViewModel.cs          # Error view model
│   ├── Views/                         # Razor view templates
│   │   ├── Home/
│   │   │   ├── Index.cshtml          # Home page
│   │   │   └── Privacy.cshtml        # Privacy page
│   │   └── Shared/
│   │       ├── _Layout.cshtml        # Master layout
│   │       ├── Error.cshtml          # Error page
│   │       └── _ValidationScriptsPartial.cshtml
│   ├── wwwroot/                       # Static assets
│   │   ├── css/
│   │   │   └── site.css              # Custom styles
│   │   ├── js/
│   │   │   └── site.js               # Custom scripts
│   │   ├── lib/                      # Third-party libraries
│   │   │   ├── bootstrap/            # Bootstrap framework
│   │   │   ├── jquery/               # jQuery library
│   │   │   └── jquery-validation/    # jQuery validation
│   │   └── favicon.ico               # Favicon
│   ├── Properties/
│   │   └── launchSettings.json       # Launch profiles
│   ├── appsettings.json              # Configuration
│   └── appsettings.Development.json  # Development configuration
│
├── ePizzaHub.API/                     # Backend API Layer
│   ├── ePizzaHub.API.csproj          # Project file
│   ├── Program.cs                     # API startup configuration
│   ├── Controllers/
│   │   └── WeatherForecastController.cs # Sample API controller
│   ├── Models/
│   │   └── WeatherForecast.cs        # Sample data model
│   ├── ePizzaHub.API.http            # HTTP test requests
│   ├── Properties/
│   │   └── launchSettings.json       # Launch profiles
│   ├── appsettings.json              # Configuration
│   └── appsettings.Development.json  # Development configuration
│
└── .git/                              # Git repository
```

## 📋 Prerequisites

Before you begin, ensure you have the following installed:

- **Visual Studio Community 2026** (v18.10.1 or later)
- **.NET 10 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/10.0)
- **Git** - [Download](https://git-scm.com)
- **PowerShell 7+** (Optional but recommended)

### Verify Installation
```powershell
# Check .NET version
dotnet --version

# Check Git version
git --version
```

## 🚀 Getting Started

### 1. Clone the Repository

```powershell
git clone https://github.com/Jayesh354/ePizzaHub_WithAIUpdate.git
cd ePizzaHub
git checkout jarohit/main-dev
```

### 2. Open in Visual Studio

1. Launch Visual Studio Community 2026
2. Open the solution file: `ePizzaHub.slnx`
3. Wait for Visual Studio to load all projects and restore NuGet packages

### 3. Build the Solution

```powershell
cd C:\Users\Tanu_Dhanu\source\repos\ePizzaHub
dotnet build
```

### 4. Run the Application

**Option A: From Visual Studio**
1. Set startup projects to both `ePizzaHub.UI` and `ePizzaHub.API` (Multi-startup project)
2. Press `F5` or click "Start Debugging"

**Option B: From Command Line**

Terminal 1 - Start the API:
```powershell
cd ePizzaHub.API
dotnet run
# API will be available at: https://localhost:7150
```

Terminal 2 - Start the UI:
```powershell
cd ePizzaHub.UI
dotnet run
# UI will be available at: https://localhost:7049
```

### 5. Access the Application

- **UI:** https://localhost:7049
- **API:** https://localhost:7150

## 🔨 Development

### Project Configuration

Both projects are configured with:
- **.NET 10** target framework
- **Nullable reference types** enabled for null-safety
- **Implicit usings** enabled for cleaner code

### Adding New Features

#### Adding a New UI Page
1. Create a new action method in `ePizzaHub.UI/Controllers/HomeController.cs`
2. Create corresponding Razor view in `ePizzaHub.UI/Views/Home/`
3. Add navigation link in `_Layout.cshtml`

#### Adding a New API Endpoint
1. Create a new controller in `ePizzaHub.API/Controllers/`
2. Define data models in `ePizzaHub.API/Models/`
3. Implement business logic in the controller actions
4. Test using the `.http` file or Postman

### Testing API Endpoints

Use the `ePizzaHub.API/ePizzaHub.API.http` file in Visual Studio to test endpoints:
- Right-click the `.http` file
- Select "Send HTTP Request"
- View response in the result panel

### Configuration Files

**appsettings.json** - General application settings
- Logging configuration
- Environment-specific settings

**appsettings.Development.json** - Development-specific overrides
- Debug settings
- Development API endpoints

## 🏗️ Building and Deployment

### Build Solution

```powershell
dotnet build
```

### Publish for Deployment

#### Publish UI
```powershell
cd ePizzaHub.UI
dotnet publish -c Release -o ./publish
```

#### Publish API
```powershell
cd ePizzaHub.API
dotnet publish -c Release -o ./publish
```

### Clean Build

```powershell
dotnet clean
dotnet build
```

## 📝 Changelog

### [Unreleased]

#### Fixed
- **[2025-01-XX]** Resolved OpenAPI source generator compatibility issue with .NET 10
  - **Issue:** Build error CS0200: Property 'IOpenApiMediaType.Example' is read-only
  - **Solution:** Removed `Microsoft.AspNetCore.OpenApi` package and OpenAPI configuration from API
  - **Files Modified:**
	- `ePizzaHub.API/ePizzaHub.API.csproj` - Removed OpenAPI package reference
	- `ePizzaHub.API/Program.cs` - Removed `AddOpenApi()` and `MapOpenApi()` calls
  - **Impact:** Project now builds successfully; OpenAPI documentation features removed

#### Added
- **[2025-01-XX]** Initial project setup
  - Created comprehensive README.md with architecture documentation
  - Established project structure and development guidelines
  - Configured .NET 10 as target framework for both UI and API layers

---

### Version History

> **Note:** This section will be updated as new releases and changes are made to the project. Each significant change should be documented here with the date, type of change (Added/Fixed/Changed/Removed/Deprecated), description, and affected files.

## 📖 Documentation

### Architecture Decisions

1. **Separation of Concerns**
   - UI and API are separate projects to enable independent scaling and deployment
   - Each layer can be updated, tested, and deployed independently

2. **.NET 10 Selection**
   - Latest stable .NET release with LTS support
   - Better performance and security features
   - Latest language features (C# 13)

3. **ASP.NET Core MVC for UI**
   - Server-side rendering for better SEO
   - Familiar pattern for rapid development
   - Easy integration with Bootstrap for responsive design

4. **RESTful API Design**
   - Standard HTTP methods (GET, POST, PUT, DELETE)
   - JSON request/response format
   - Stateless communication

### Future Enhancements

- [ ] Implement database layer (SQL Server or PostgreSQL)
- [ ] Add authentication and authorization (Identity/JWT)
- [ ] Create entity models for Pizza, Order, User, etc.
- [ ] Implement pizza catalog service
- [ ] Add shopping cart and order management
- [ ] Integrate payment processing
- [ ] Add AI-powered recommendations
- [ ] Implement real-time order tracking
- [ ] Set up CI/CD pipeline (GitHub Actions)
- [ ] Docker containerization for deployment
- [ ] Kubernetes orchestration support
- [ ] Add comprehensive API documentation (Swagger/OpenAPI)
- [ ] Implement caching strategies
- [ ] Add logging and monitoring (Application Insights)
- [ ] Performance optimization and load testing

## 🤝 Contributing

1. Create a feature branch from `jarohit/main-dev`
2. Make your changes and commit with clear messages
3. Update this README.md with any architectural or feature changes
4. Push to your branch and create a Pull Request
5. Ensure all changes are documented in the [Changelog](#changelog)

## 📄 License

This project is part of the ePizzaHub initiative. Check the repository for license information.

## 📞 Support

For issues, questions, or suggestions, please refer to the repository issues page or contact the development team.

---

**Last Updated:** January 2025  
**Framework Version:** .NET 10  
**Status:** Active Development
