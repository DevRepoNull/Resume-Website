using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Education;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class EducationController : AdminBaseController
    {
        #region Education Constructor

        private readonly IEducationService _education;

        public EducationController(IEducationService education)
        {
            _education = education;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _education.GetEducationDataListAsync());
        }

        public async Task<IActionResult> LoadEducationFormModalAsync(long id)
        {
            UpsertEducationViewModel result = await _education.FillUpsertEducationViewModelAsync(id);

            return PartialView("Partials/_EducationFormModal", result);
        }

        public async Task<IActionResult> SubmitEducationFormModalAsync(UpsertEducationViewModel education)
        {
            var result = await _education.UpsertEducationAsync(education);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteEducationAsync(long id)
        {
            var result = await _education.DeleteEducationAsync(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }
    }
}
