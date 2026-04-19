using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class SocialMediaController : AdminBaseController
    {
        #region Social Media Constructor

        private readonly ISocialMediaService _mediaService;

        public SocialMediaController(ISocialMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _mediaService.GetSocialMediaDataAsync());
        }

        public async Task<IActionResult> LoadSocialMediaFormModalAsync(long id)
        {
            UpsertSocialMediaViewModel result = await _mediaService.FillSocialMediaAsync(id);

            return PartialView("Partials/_SocialMediaFormModal", result);
        }

        public async Task<IActionResult> SubmitSocialMediaFormModalAsync(UpsertSocialMediaViewModel socialMedia)
        {
            bool result = await _mediaService.UpsertSocialMediaAsync(socialMedia);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteSocialMediaAsync(long id)
        {
            bool result = await _mediaService.DeleteSocialMediaAsync(id);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }
    }
}
