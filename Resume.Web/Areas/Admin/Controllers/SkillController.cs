using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class SkillController : AdminBaseController
    {
        #region Skill Constructor

        private readonly ISkillService _skill;

        public SkillController(ISkillService skill)
        {
            _skill = skill;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _skill.GetSkillDataAsync());
        }

        public async Task<IActionResult> LoadSkillFormModalAsync(long id)
        {
            UpsertSkillViewModel result = await _skill.FillUpsertSkillViewModel(id);

            return PartialView("Partials/_SkillFormModal", result);
        }

        public async Task<IActionResult> SubmitSkillFormModalAsync(UpsertSkillViewModel skill)
        {
            var result = await _skill.UpsertSkillAsync(skill);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteSkillAsync(long id)
        {
            var result = await _skill.DeleteSkillAsync(id);

            if (result) return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }
    }
}
