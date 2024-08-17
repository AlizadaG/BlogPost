using CeyhunApplication.Abstractions.Repositories;
using CeyhunApplication.Abstractions.Services;
using CeyhunApplication.Concretes.Repositories;
using CeyhunApplication.Concretes.Services;
using CeyhunApplication.Data;
using Microsoft.EntityFrameworkCore;
using Sentry.Profiling;

var builder = WebApplication.CreateBuilder(args);


builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://bfc6ac34fb2d3f070a1e83964fbb8464@o4507782910115840.ingest.us.sentry.io/4507783035748352";
    o.Debug = true;
    o.TracesSampleRate = 1.0;
    o.ProfilesSampleRate = 1.0;
    o.AddIntegration(new ProfilingIntegration(
        TimeSpan.FromMilliseconds(500)
    ));
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("default") ?? throw new InvalidOperationException("Connection string 'default' not found.")));

//Add Scoped to IoC 
builder.Services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
builder.Services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSentryTracing();
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
