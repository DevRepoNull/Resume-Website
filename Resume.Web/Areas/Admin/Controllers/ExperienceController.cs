using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ExperienceController : AdminBaseController
    {
        #region Experience Serviec Constructor

        private readonly IExperienceService _experience;

        public ExperienceController(IExperienceService experience)
        {
            _experience = experience;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _experience.GetExperienceDataListAsync());
        }

        public async Task<IActionResult> LoadExperienceFormModalAsync(long id)
        {
            UpsertExperienceViewModel result = await _experience.FillUpsertExperienceAsync(id);

            return PartialView("Partials/_ExperienceFormModal", result);
        }

        public async Task<IActionResult> SubmitExperienceFormModalAsync(UpsertExperienceViewModel experience)
        {
            var result = await _experience.UpsertExperienceAsync(experience);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteExperienceAsync(long id)
        {
            var result = await _experience.DeleteExperienceAsync(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }
    }
}
