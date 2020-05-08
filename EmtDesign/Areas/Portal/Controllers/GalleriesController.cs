using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamTechSDK.Common.Services.ContentService.Menus;
using TamTechSDK.Common.Services.ContentService.Galleries;
using TamTechSDK.Web.Controllers.Portal;
using TamTechSDK.Web.Services.Telemetry;
using Microsoft.Extensions.Localization;
using TamTechSDK.Web;
using TamTechSDK.Common.Services.ContentService.Galleries.Models;
using TamTechSDK.Common.Models.Pagination;

namespace EmtDesign.Areas.Portal.Controllers
{
    
    public class GalleriesController : GalleriesBaseController
    {
        IGalleriesService _galleriesService;
        public GalleriesController(ITelemetryClientService telemetryClientService,
            IMenusServices menusServices, IGalleriesService galleriesService)
            : base(telemetryClientService, menusServices, galleriesService)
        {
            _galleriesService = galleriesService;
        }


        [ActionName("s")]
        public override async Task<IActionResult> Section(PaginationModel Pagination, string slug)
        {


            GalleryList galleries = new GalleryList();

            try
            {

                var result = await _galleriesService.GetPublicListAsync(Pagination, slug);
                galleries.Data = result.Data;
                galleries.Pagination = result.Pagination;

            }
            catch (Exception ex)
            {
                TrackException(ex);
            }
            return View("Index", galleries);

        }
    }


}