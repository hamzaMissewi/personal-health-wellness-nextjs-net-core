# Personal Health & Wellness Application

A comprehensive health and wellness tracking application built with Next.js frontend and ASP.NET Core backend.

## Features

-   **Health Metrics Tracking**: Monitor steps, heart rate, water intake, sleep duration, and calories burned
-   **AI-Powered Insights**: Get personalized health insights and recommendations
-   **Wellness Planning**: Create and track personalized wellness plans
-   **Real-time Updates**: SignalR integration for live health data updates
-   **Health Scoring**: Comprehensive health score calculation across multiple categories

## Prerequisites

### Backend Requirements

-   .NET 8.0 SDK
-   SQL Server (LocalDB or full SQL Server)
-   Visual Studio 2022 or VS Code with C# extension

### Frontend Requirements

-   Node.js 18+
-   npm or yarn

## Getting Started

### 1. Backend Setup (ASP.NET Core)

1. **Navigate to the backend directory:**

    ```bash
    cd backend/HealthWellnessAPI
    ```

2. **Restore NuGet packages:**

    ```bash
    dotnet restore
    ```

<!-- 3. **Create the database:**

    ```bash
    dotnet ef database update
    ```

    If you don't have the EF tools installed, install them first:

    ```bash
    dotnet tool install --global dotnet-ef
    ``` -->

3. **The database will be automatically created** when you run the application for the first time.

4. **Run the backend API:**

    ```bash
    dotnet run
    ```

    The API will be available at:

    - **API**: https://localhost:7001
    - **Swagger UI**: https://localhost:7001/swagger

### 2. Frontend Setup (Next.js)

1. **Navigate to the project root:**

    ```bash
    cd /path/to/personal-health-wellness-nextjs-net-core
    ```

2. **Install dependencies:**

    ```bash
    npm install
    ```

3. **Run the development server:**

    ```bash
    npm run dev
    ```

    The frontend will be available at: http://localhost:3000

## API Endpoints

The backend provides the following main endpoints:

-   `GET /api/health/metrics/{userId}` - Get user health metrics
-   `PUT /api/health/metrics/{userId}` - Update health metrics
-   `GET /api/health/insights/{userId}` - Get health insights
-   `GET /api/health/wellness-plan/{userId}` - Get wellness plan
-   `POST /api/health/wellness-plan/{userId}` - Create wellness plan
-   `GET /api/health/score/{userId}` - Get health score
-   `GET /api/health/predictions/{userId}` - Get ML predictions

## Database

The application uses Entity Framework Core with SQL Server. The database will be automatically created when you first run the application.

### Connection String

The default connection string uses LocalDB:

```
Server=(localdb)\mssqllocaldb;Database=HealthWellnessDB;Trusted_Connection=true;MultipleActiveResultSets=true
```

## Development

### Backend Development

-   The backend uses ASP.NET Core 8.0 with Entity Framework Core
-   ML.NET is used for health predictions
-   SignalR provides real-time communication
-   Swagger is enabled for API documentation

### Frontend Development

-   Built with Next.js 15 and React 19
-   Uses Tailwind CSS for styling
-   Radix UI components for accessible UI elements
-   AI SDK for OpenAI integration

## Troubleshooting

### Common Issues

1. **Database Connection Error**

    - Ensure SQL Server LocalDB is installed
    - Check if the connection string is correct in `appsettings.json`

2. **Port Conflicts**

    - Backend runs on port 7001 by default
    - Frontend runs on port 3000 by default
    - Check if these ports are available

3. **Missing Dependencies**

    - Run `dotnet restore` in the backend directory
    - Run `npm install` in the project root

4. **CORS Issues**
    - The backend is configured to allow requests from `http://localhost:3000`
    - Ensure both applications are running on the correct ports

## Project Structure

```
personal-health-wellness-nextjs-net-core/
├── app/                          # Next.js frontend
│   ├── api/                      # API routes
│   ├── components/               # React components
│   └── ...
├── backend/                      # ASP.NET Core backend
│   └── HealthWellnessAPI/
│       ├── Controllers/          # API controllers
│       ├── Data/                 # Entity Framework context
│       ├── Models/               # Data models
│       ├── Services/             # Business logic services
│       └── Hubs/                 # SignalR hubs
├── components/                   # Shared UI components
└── ...
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test both backend and frontend
5. Submit a pull request

## License

This project is licensed under the MIT License.
