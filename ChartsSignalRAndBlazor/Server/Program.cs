using ChartsSignalRAndBlazor.Server.Data;
using ChartsSignalRAndBlazor.Server.Hubs;
using ChartsSignalRAndBlazor.Server.Subscription;
using ChartsSignalRAndBlazor.Server.Subscription.Middleware;
using ChartsSignalRAndBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SatisDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQL")));
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowCredentials().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed(x => true)));
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddSingleton<DatabaseSubscription<Satislar>>();
builder.Services.AddSingleton<DatabaseSubscription<Personeller>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors();
app.UseDatabaseSubscription<DatabaseSubscription<Satislar>>("Satislar");
app.UseDatabaseSubscription<DatabaseSubscription<Personeller>>("Personeller");

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.MapHub<SatisHub>("/satishub");

app.Run();
