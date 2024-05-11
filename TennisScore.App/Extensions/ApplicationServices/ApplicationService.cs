using Microsoft.Extensions.DependencyInjection;
using TennisScore.Business.Interfaces.Services;
using TennisScore.Business.Services.MatchManagementDecorator;

namespace TennisScore.App.Extensions.ApplicationServices
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IMatchManagement, ValidateInitialShootService>();
            service.Decorate<IMatchManagement, SetChoiceService>();

            return service;
        }
    }
}
