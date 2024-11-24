using lab7.Data; // Простір імен для DataContext
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Tests")]


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Додаємо підтримку контролерів

// Налаштування бази даних
builder.Services.AddDbContext<DataContext>(options =>
{
    var configuration = builder.Configuration;
    var dbType = configuration.GetValue<string>("DatabaseType");
    if (dbType == "MsSql")
        options.UseSqlServer(configuration.GetConnectionString("MsSql"));
    else if (dbType == "Postgres")
        options.UseNpgsql(configuration.GetConnectionString("Postgres"));
    else if (dbType == "Sqlite")
        options.UseSqlite(configuration.GetConnectionString("Sqlite"));
    else
        options.UseInMemoryDatabase("InMemoryDb");
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Налаштування Swagger для тестування
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Перенаправлення на HTTPS

app.MapControllers(); // Підключення маршрутів контролерів

app.Run();
