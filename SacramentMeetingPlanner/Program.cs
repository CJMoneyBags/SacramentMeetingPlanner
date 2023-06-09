﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SacramentMeetingPlanner.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SacramentMeetingPlannerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SacramentMeetingPlannerContext") ?? throw new InvalidOperationException("Connection string 'SacramentMeetingPlannerContext' not found.")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SacramentMeetingPlannerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SacramentMeetingPlannerContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetService<SacramentMeetingPlannerContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
