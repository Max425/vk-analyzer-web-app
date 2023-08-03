using Analyst;
using DataBaseAPI;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAnalystWorker, AnalystWorker>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();
builder.Services.AddScoped<IComUserRepository, IComUserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// builder.Configuration["PostgressPass"] = "2";

var app = builder.Build();

app.MapControllerRoute(name: "default", pattern: "{controller=Process}/{action=Request}/{id?}");

app.MapGet("/", (context) =>
{
    // context.Response.Redirect("/Process/Request");
    return Task.CompletedTask;
});

app.Run();
