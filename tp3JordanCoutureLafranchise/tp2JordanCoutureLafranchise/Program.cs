using tp2JordanCoutureLafranchise.Models;

var builder = WebApplication.CreateBuilder(args); // Crée une web app avec les paramètres envoyés
builder.Services.AddControllersWithViews(); // Permet MVC
builder.Services.AddRazorPages(); // Permet utilisation de Razor

builder.Services.AddSingleton<BaseDeDonnees>(); // Permet l'utilisation du Singleton
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option => { option.IdleTimeout = TimeSpan.FromMinutes(20); });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = context => context.Context.Response.Headers.Add("Cache-Control", "no-cache")
    });
}
else
{
    app.UseStaticFiles();
}

app.UseSession();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" });
});

app.MapRazorPages();
app.Run();

// Doc
// Environnements: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-7.0
// Fichiers statiques et wwwroot : https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-7.0
// Gestion de la cache : https://learn.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-7.0