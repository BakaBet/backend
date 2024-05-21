using BakaBack;
using BakaBack.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configuration des services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

// Configuration du contexte de base de données pour les événements sportifs
builder.Services.AddDbContext<SportsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SportsConnection")));

// Configuration du contexte de base de données pour les comptes utilisateurs
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("UsersConnection")));

// Ajout des services Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Ajout de UserService
builder.Services.AddScoped<UserService>();


builder.Services.AddScoped<SportsOddsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); // Ajouter cette ligne pour utiliser l'authentification
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages(); // Ajouter cette ligne pour mapper les pages Razor

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var sportsOddsService = services.GetRequiredService<SportsOddsService>();

    await sportsOddsService.GetAndSaveMatchesAsync();
}

app.Run();
