using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtDesign.AppStartup.DirectBackendServices.IdentityService.ApplicationServices;
using EmtDesign.AppStartup.MicroServices.ApplicationServices;
using EmtDesign.Services.Configurations.AppSetting.Constants;

namespace EmtDesign.AppStartup.WebApplication.ApplicationServices
{
    public static class AuthenticationServicesConfigurations
    {
        public static void AddAuthenticationServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
                services.MicroServices_AddIdentityServerAuthentication(configuration);
            }
            else
            {
                services.IdentityService_DirectedBackendServicesConfigurations_ConfigureServices(configuration);
            }
        }
    }
}
