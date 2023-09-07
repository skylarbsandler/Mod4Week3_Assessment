using CommerceMvc.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CommerceMvcContext>(options =>
    options
        .UseNpgsql(builder.Configuration["COMMERCEMVC_DBCONNECTIONSTRING"]
          ?? throw new InvalidOperationException(
                        "Connection string 'CommerceMVCDb' not found."
                    )
            )
        .UseSnakeCaseNamingConvention());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
