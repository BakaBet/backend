using BakaBack.Infrastructure;
using BakaBack.Infrastructure.Contexts;
using BakaBack.Infrastructure.Models;
using BakaBack.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BakaBack.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BakaBack.Domain.Services;
using BakaBack.In.Services;
using BakaBack.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBetRepository, BetRepository>();

builder.Services.AddScoped<IOddsService, OddsService>();
builder.Services.AddScoped<SportsOddsService>();
builder.Services.AddScoped<IBetService, BetService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();

// Register TimerService as a singleton but use a scoped service provider
builder.Services.AddSingleton<TimerService>(serviceProvider =>
{
    var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
    var scope = scopeFactory.CreateScope();
    var betService = scope.ServiceProvider.GetRequiredService<IBetService>();
    return new TimerService(betService);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var sportsOddsService = services.GetRequiredService<SportsOddsService>();

    var timerService = services.GetRequiredService<TimerService>();

    //await sportsOddsService.GetAndSaveMatchesAsync();
}

app.Run();