﻿using Amazon.S3;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using SchoolMealsOrderingSystem.Core.Contracts;
using SchoolMealsOrderingSystem.Core.Services;
using SchoolMealsOrderingSystem.Data;
using SchoolMealsOrderingSystem.Data.Entities;
using static SchoolMealsOrderingSystem.Data.Constants.GeneralConstants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SchoolMealsOrderingSystemDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.User.AllowedUserNameCharacters = AllowedUserNameCharacters;

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SchoolMealsOrderingSystemDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath= "/Identity/Login";
});


builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
})
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


builder.Services.AddScoped<ISchoolServices, SchoolServices>();
builder.Services.AddScoped<IChildServices, ChildServices>();
builder.Services.AddScoped<IParentUserServices, ParentUserServices>();
builder.Services.AddScoped<ISchoolUserServices, SchoolUserServices>();
builder.Services.AddScoped<IMealServices, MealServices>();
builder.Services.AddScoped<IDailyMenuServices, DailyManuServices>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddSingleton<IAmazonS3, AmazonS3Client>();
builder.Services.AddAWSService<IAmazonS3>();


var app = builder.Build();

var supportedCultures = new[] { "en", "bg" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapDefaultControllerRoute();
});


app.Run();
