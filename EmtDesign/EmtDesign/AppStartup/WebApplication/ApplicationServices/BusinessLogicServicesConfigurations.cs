using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtDesign.Services.Configurations.AppSetting.Constants;

namespace EmtDesign.AppStartup.WebApplication.ApplicationServices
{
    public static class BusinessLogicServicesConfigurations
    {
        public static void AddBusinessLogicServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
                services._AddBusinessLogicMicroServicesConfigurations(configuration);
            }
            else
            {
                services._AddBusinessLogicDirectBackendServicesConfigurations();
            }
        }
    }
}
