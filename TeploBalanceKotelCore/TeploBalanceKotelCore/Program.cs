using AutoMapper;
using TeploBalanceKotelCore;
using Microsoft.Extensions.Options;
using TeploBalanceKotelCore.Data;
using TeploBalanceKotelCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using TeploBalanceKotelCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext_TverdToplivo>(
    options => options
        .UseSqlite("Data Source= TeploBalanceKotelCoreBase.db")
    );
// AutoMapper Configuration
var mapper = new MapperConfiguration(mc => mc.AddProfile<MapperProfile>())
    .CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddScoped<TverdToplivoService>();

//Сервис авторизации
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Auth/Index");
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
//middleware для авторизации
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
