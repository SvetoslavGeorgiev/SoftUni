using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolMealsOrderingSystem.Core.Contracts;
using SchoolMealsOrderingSystem.Core.Services;
using SchoolMealsOrderingSystem.Data;
using SchoolMealsOrderingSystem.Data.Entities;
using static SchoolMealsOrderingSystem.Data.Constants.GeneralConstants;

var builder = WebApplication.CreateBuilder(args);

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


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISchoolServices, SchoolServices>();
builder.Services.AddScoped<IChildServices, ChildServices>();
builder.Services.AddScoped<IParentUserServices, ParentUserServices>();
builder.Services.AddScoped<ISchoolUserServices, SchoolUserServices>();

var app = builder.Build();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();
