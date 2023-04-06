var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapGet("/", (context) =>
{
    context.Response.Redirect("/Process/Request");
    return Task.CompletedTask;
});

app.Run();
