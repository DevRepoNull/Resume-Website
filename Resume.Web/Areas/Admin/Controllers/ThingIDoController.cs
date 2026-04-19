using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class ThingIDoController : AdminBaseController
    {
        #region ThingIDo Constructor

        private readonly IThingIDoService _doService;

        public ThingIDoController(IThingIDoService doService)
        {
            _doService = doService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _doService.GetAllThingIDoDataAsync());
        }

        public async Task<IActionResult> LoadThingIDoFromModal(long id)
        {
            CreateOrEditThingIDoViewModel result = await _doService.FillUpsertThingIDoViewModelAsync(id);

            return PartialView("Partials/_ThingIDoModalPartial", result);
        }

        public async Task<IActionResult> SubmitThingIDoForModalAsync(CreateOrEditThingIDoViewModel thingIDo)
        {
            var result = await _doService.CreateOrEditThingIDo(thingIDo);

            if (result) 
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeleteThingIDoAsync(long id)
        {
            var result = await _doService.DeleteThingIDoAsync(id);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }
    }
}
