using Project.Youtube.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Youtube.Models.Context;
using Project.Youtube.Models.Entities;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddAuthentication(googleOptions =>
{
    googleOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    googleOptions.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
   
}).AddCookie().AddGoogle(GoogleDefaults.AuthenticationScheme, googleOptions =>
{
    googleOptions.ClientId = configuration.GetSection("GoogleKeys:ClientId").Value;
    googleOptions.ClientSecret = configuration.GetSection("GoogleKeys:ClientId").Value;
});
builder.Services.AddDbContextPool<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<MyContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<YouTubeAPIClient>(client =>
{
    client.BaseAddress = new Uri("https://www.googleapis.com/youtube/v3/");
});
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
