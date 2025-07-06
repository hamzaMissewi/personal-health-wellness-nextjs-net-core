using HealthWellnessAPI.Services;
using HealthWellnessAPI.Data; // cursor
using HealthWellnessAPI.Hubs; // ai  cursor
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJS", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Add Entity Framework
builder.Services.AddDbContext<HealthWellnessContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add custom services
builder.Services.AddScoped<IHealthService, HealthService>();
builder.Services.AddScoped<IMLPredictionService, MLPredictionService>();
builder.Services.AddScoped<INotificationService, NotificationService>(); // ai cursor

// Add SignalR for real-time updates
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowNextJS");
app.UseAuthorization();
app.MapControllers();

// Add SignalR hub
app.MapHub<HealthHub>("/healthHub");

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<HealthWellnessContext>();
    context.Database.EnsureCreated();
}

app.Run();
