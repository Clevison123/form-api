using FormAPI.Data;
using FormAPI.Middleware;
using FormAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL")
                           ?? builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString); // PostgreSQL
});


// Services
builder.Services.AddScoped<FormService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Controllers
builder.Services.AddControllers();

var app = builder.Build();

// Middlewares
app.UseCors("AllowAll");
app.UseErrorHandler();
app.MapControllers();

app.Run();
