using Lab6.Data; 
using Lab6.SeedData; 
using Lab6.Services; 
using Auth0.AspNetCore.Authentication; 
using Microsoft.EntityFrameworkCore; 
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinancialDbContext>(options =>
{
    var dbConfig = builder.Configuration.GetSection("DatabaseConfig");
    var provider = dbConfig["Provider"] ?? "SqlServer";

    switch (provider)
    {
        case "SqlServer":
            options.UseSqlServer(dbConfig.GetSection("ConnectionStrings")["SqlServer"]);
            break;
        case "PostgreSQL":
            options.UseNpgsql(dbConfig.GetSection("ConnectionStrings")["PostgreSQL"]);
            break;
        case "SQLite":
            options.UseSqlite(dbConfig.GetSection("ConnectionStrings")["SQLite"]);
            break;
        case "InMemory":
            options.UseInMemoryDatabase("InMemoryDb");
            break;
        default:
            throw new Exception($"Unknown database provider: {provider}");
    }
});

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<AuthService>();

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
    options.ClientSecret = builder.Configuration["Auth0:ClientSecret"]!;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FinancialDbContext>();
    if (builder.Configuration.GetSection("DatabaseConfig")["Provider"] != "InMemory")
    {
        context.Database.Migrate(); 
    }
    SeedData.Initialize(context); 
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
