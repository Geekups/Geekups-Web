using DayanaWeb.Shared.BaseServices;
using DayanaWeb.Shared.EntityFramework.Common;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// this code define my normal data context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("IllConnection"));
});

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
var appName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

builder.Configuration.AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
string address = configuration.GetValue<string>("urls");

#region builder

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// register an HttpClient that points to itself
builder.Services.AddSingleton(sp =>
{
    // Get the address that the app is currently running at
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    var baseAddress = addressFeature.Addresses.First();
    return new HttpClient { BaseAddress = new Uri(baseAddress) };
});
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddMvc();
builder.Services.AddMudServices();
#endregion

var app = builder.Build();

#region app


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


// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.MapRazorPages();
app.MapControllers();
app.UseRouting();
app.MapRazorPages(); // <- Add this (for prerendering)
app.MapFallbackToPage("/_Host"); // <- Change method + file (for prerendering)

app.Run();

#endregion
