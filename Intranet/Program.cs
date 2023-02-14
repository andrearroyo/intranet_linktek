using CurrieTechnologies.Razor.SweetAlert2;
using Intranet.Data;
using Intranet.Services;
using Intranet.Services.Planes;
using Intranet.ServicesInterfaces;
using Intranet.ServicesInterfaces.Planes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSweetAlert2();
builder.Services.AddTelerikBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddTransient<IConsorcioService, ConsorcioService>();
builder.Services.AddTransient<IEmpresaService, EmpresaService>();
builder.Services.AddTransient<ISalaService, SalaService>();

builder.Services.AddTransient<IPaqueteService, PaqueteService>();
builder.Services.AddTransient<ISistemaService, SistemaService>();
builder.Services.AddTransient<IPaqueteSistemaService, PaqueteSistemaService>();
builder.Services.AddTransient<ILicenciaService, LicenciaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
