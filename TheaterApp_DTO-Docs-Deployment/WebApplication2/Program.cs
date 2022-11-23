using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.Interfaces;
using WebApplication2.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbContext")));
} else
{
    builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));
}
builder.Services.AddTransient<ICast, CastService>();
//AddDbContext - TestDbContext  |  SQLiteContext

/*
 // Register the Swagger services
    services.AddSwaggerDocument();
*/
//builder.Services.AddSwaggerDocument();
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = document =>
    {
        document.Info.Version = "v1";
        document.Info.Title = "Casts API";
        document.Info.Description = "A simple ASP.NET Core MVC web API";
        document.Info.TermsOfService = "None";
        document.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "DJ",
            Email = "dj@code-crew.org",
            Url = "https://dij.io"
        };
        document.Info.License = new NSwag.OpenApiLicense
        {
            Name = "Use under MIT",
            Url = "https://opensource.org/licenses/MIT"
        };
    };
});

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
//{
//    options.User.RequireUniqueEmail = true;
//    // There are other options like this
//}).AddEntityFrameworkStores<TestDbContext>();

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
//app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


/* 
 // Register the Swagger generator and the Swagger UI middlewares
    app.UseOpenApi();
    app.UseSwaggerUi3();
 */
app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();
