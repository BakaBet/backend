using BakaBack;
using Microsoft.EntityFrameworkCore;
using BakaBack.Contexts;
using BakaBack.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<SportsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<SportsBetRepository>();
builder.Services.AddScoped<SportsOddsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var sportsOddsService = services.GetRequiredService<SportsOddsService>();

    //await sportsOddsService.GetAndSaveMatchesAsync();
}

app.Run();