using JobBoard;
using JobBoard.Services;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using JobBoard.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JobBoardContextConnection") ?? throw new InvalidOperationException("Connection string 'JobBoardContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IDbService,DbService>();

builder.Services.AddDbContext<DbContextJobBoard>( builder =>
{
    builder.UseSqlServer(@"Server=(localdb)\JobBoard;Database=JobBoard;Trusted_Connection=True");
});

builder.Services.AddDefaultIdentity<JobBoardAccount>(options => {
    options.SignIn.RequireConfirmedAccount = false;

    options.Password.RequiredLength = 3;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    }
).AddRoles<IdentityRole>()     .AddEntityFrameworkStores<DbContextJobBoard>().AddDefaultTokenProviders();

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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
