global using EncoreTIX.Shared.Models;
global using EncoreTIX.Shared.Response;
global using EncoreTIX.Server.Helpers;
global using Newtonsoft.Json;
global using Newtonsoft.Json.Linq;
global using AutoMapper;
global using EncoreTIX.Server.Services.AttractionService;
global using EncoreTIX.Shared.Dtos;
global using EncoreTIX.Shared.Models;
using Microsoft.AspNetCore.ResponseCompression;
using EncoreTIX.Server.Services.EventService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#region Helpers
builder.Services.AddScoped<IHttpHelper, HttpHelper>();
#endregion

#region Services
builder.Services.AddScoped<IAttractionService, AttractionService>();
builder.Services.AddScoped<IEventService, EventService>();
#endregion

var app = builder.Build();

app.UseSwaggerUI();

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

app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
