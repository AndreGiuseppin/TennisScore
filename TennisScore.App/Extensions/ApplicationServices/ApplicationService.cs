using Microsoft.Extensions.DependencyInjection;
using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Services.MatchManagementDecorator;

namespace TennisScore.App.Extensions.ApplicationServices
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IMatchManagement, StartRallyService>();
            service.Decorate<IMatchManagement, ValidateInitialShootService>();
            service.Decorate<IMatchManagement, MatchManagementService>();
            service.Decorate<IMatchManagement, SetChoiceService>();

            return service;
        }
    }
}
