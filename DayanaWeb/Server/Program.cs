using DayanaWeb.Shared.BaseServices;
using DayanaWeb.Shared.EntityFramework.Common;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// register an HttpClient that points to itself
builder.Services.AddScoped(sp =>
{
    // Get the address that the app is currently running at
    var server = sp.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    var baseAddress = addressFeature.Addresses.First();
    return new HttpClient { BaseAddress = new Uri(baseAddress) };
});
builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// https://learn.microsoft.com/en-us/aspnet/core/blazor/components/prerendering-and-integration?view=aspnetcore-7.0&pivots=webassembly
app.MapRazorPages();
app.MapControllers();
//app.MapFallbackToFile("index.html");
app.MapRazorPages(); // <- Add this (for prerendering)
app.MapFallbackToPage("/_Host"); // <- Change method + file (for prerendering)
app.Run();
