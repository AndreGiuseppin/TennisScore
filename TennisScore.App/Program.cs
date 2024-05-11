using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TennisScore.App.Extensions.ApplicationServices;
using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Models;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddServices();

using IHost host = builder.Build();
using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;
var matchManagement = provider.GetRequiredService<IMatchManagement>();

MatchManagement match = new();
matchManagement.Process(match);