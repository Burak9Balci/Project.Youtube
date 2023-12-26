using Project.Youtube.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Youtube.Models.Context;
using Project.Youtube.Models.Entities;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Index}/{action=GetChannelVideos}/{id?}");

app.Run();
