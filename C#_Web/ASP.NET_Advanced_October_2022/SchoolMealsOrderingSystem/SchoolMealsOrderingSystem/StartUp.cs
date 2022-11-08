using Microsoft.EntityFrameworkCore;
using SchoolMealsOrderingSystem.Core.Contracts;
using SchoolMealsOrderingSystem.Core.Services;
using SchoolMealsOrderingSystem.Data;
using SchoolMealsOrderingSystem.Data.Entities;

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

})
    .AddEntityFrameworkStores<SchoolMealsOrderingSystemDbContext>();


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISchoolServices, SchoolServices>();
builder.Services.AddScoped<IChildServices, ChildServices>();

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
