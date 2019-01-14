using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TamTechBackendSDK.EmailService.Services;
using TamTechSDK.Common.Models.ContactUs;
using TamTechSDK.Common.Services.ContentService.City;
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Pages;
using TamTechSDK.Common.Services.ContentService.Posts;
using TamTechSDK.Common.Services.ContentService.Request;
using TamTechSDK.Common.Services.ContentService.Services;
using TamTechSDK.Common.Services.ContentService.Sliders;

using TamTechSDK.Common.Services.Email;
using TamTechSDK.Web;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Configurations.AppSetting;
using TamTechSDK.Web.Services.Telemetry;

namespace EmtDesign.Areas.Portal.Controllers
{

    public class HomeController : HomeBaseController
    {
        private readonly IPageService _pageService;
        private readonly IWebApplicationSettingsService _appSettingsService;
        private readonly ISlidersServices _sliderService;
        private readonly IGalleriesService _GalleriesService;
        private readonly IPostsService _postservice;



        public HomeController(ITelemetryClientService telemetryClientService,
                               IPageService pageService,
                               IMenusServices menusServices,
                               IConfiguration configuration,
                               IEmailSenderService emailSender, IWebApplicationSettingsService appSettingsService, IServicesService servicesservice,
                               ISlidersServices sliderService,
                               IRequestService requestService,
                               ICityService cityService,
                               IGalleriesService GalleriesService,
                               IPostsService postservice)
                               : base(telemetryClientService, pageService,
                                        menusServices, configuration, emailSender, appSettingsService,
                                        servicesservice, sliderService, requestService, cityService)

        {



            _pageService = pageService;
            _appSettingsService = appSettingsService;
            _GalleriesService = GalleriesService;
            _sliderService = sliderService;
            _postservice = postservice;


        }

        public override async Task<IActionResult> Index()
        {

            var publicMainSlider = await _sliderService.GetPublicByKeyAsync(_appSettingsService.GetHomePageMainSliderKey());
            var Posts = await _postservice.GetPublicListAsync(5);
            var galleries = await _GalleriesService.GetPublicListAsync(5);
            var aboutSummary = await _pageService.GetPublicPageSummaryByIdAsync(_appSettingsService.GetHomePageSummuryId());
            /*
             try
            { 
                var publicMainSlider = await _sliderService.GetPublicByKeyAsync(_appSettingsService.GetHomePageMainSliderKey());
                
                

                if (aboutSummary.Success)
                {
                    ViewBag.aboutSummary = aboutSummary.Data;
                }
                var services = await _servicesservice.GetPublicListAsync(4);

                if (services.Success)
                {
                    ViewBag.services = services.Data;
                }
                if (publicMainSlider.Success)
                {
                    ViewBag.publicMainSlider = publicMainSlider.Data;
                }
                var publicClientsSlider = await _sliderService.GetPublicByKeyAsync(_appSettingsService.GetHomePageCarouselSliderKey());
                if (publicClientsSlider.Success)
                {
                    ViewBag.publicClientsSlider = publicClientsSlider.Data;
                }

            }
            catch(Exception ex)
            { 
            } 
             */
            return base.View();
        }
    }
}