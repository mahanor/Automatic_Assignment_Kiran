using AutomaticInfotch_Assignment.DataContext;
using AutomaticInfotch_Assignment.Repository.IRepository;
using AutomaticInfotch_Assignment.Repository.RepositoryImpl;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));

builder.Services.AddTransient<IMaterialRepository, MaterialRepositoryImpl>();
builder.Services.AddTransient<IVendorRepository, VendorRepositoryImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vendors}/{action=Index}/{id?}");

app.Run();
