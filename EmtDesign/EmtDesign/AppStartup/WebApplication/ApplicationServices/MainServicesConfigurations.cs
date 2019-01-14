using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EmtDesign.AppStartup.DirectBackendServices.ContentService.ApplicationServices;
using EmtDesign.AppStartup.DirectBackendServices.EmailService;
using EmtDesign.AppStartup.DirectBackEndServices.FilesServices;
using EmtDesign.AppStartup.MicroServices.ApplicationServices;
using EmtDesign.Services.Configurations.AppSetting.Constants;

namespace EmtDesign.AppStartup.WebApplication.ApplicationServices
{
    public static class MainServicesConfigurations
    {
        public static void AddMainServicesConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            bool useMicroServices = configuration.GetSection(AppSettings.WebApplicationSettings)
                                                 .GetSection(AppSettings.WebApplication_UseMicroServices).Get<bool>();
            if (useMicroServices)
            {
                services.MicroServices_AddUrlBackendSettingsServicesConfigurations(configuration);

                services.MicroServices_AddProvidersServicesConfigurations();
            }
            else
            {
                services.DirectBackendServices_ContentService_AddCommonHelpersServicesConfigurations(configuration);

                services.DirectBackendServices_ContentService_AddContentBLLServicesConfigurations();

                services.DirectBackendServices_ContentService_AddRepositoriesConfigurations(configuration);

                services.DirectBackendServices_ContentService_AddFluentValidationConfigurations();

                services.DirectBackendServices_AddFilesServicesConfigurationsConfigurations(configuration);

                services.DirectBackendServices_AddEmailServicesConfigurations(configuration);
            }
        }
    }
}
