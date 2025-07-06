@echo off
echo Starting Health & Wellness Backend API...
echo.

cd backend\HealthWellnessAPI

echo Restoring NuGet packages...
dotnet restore

@REM echo.
@REM echo Installing Entity Framework tools...
@REM dotnet tool install --global dotnet-ef

@REM echo.
@REM echo Creating/updating database...
@REM dotnet ef database update

echo.
echo Starting the API server...
echo The API will be available at: https://localhost:7001
echo Swagger UI will be available at: https://localhost:7001/swagger
echo.
echo Press Ctrl+C to stop the server
echo.

dotnet run

pause 