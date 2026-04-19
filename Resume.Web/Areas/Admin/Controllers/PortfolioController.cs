using Microsoft.AspNetCore.Mvc;
using Resume.Application.Extensions;
using Resume.Application.Generator;
using Resume.Application.Services.Interfaces;
using Resume.Application.StaticTools;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class PortfolioController : AdminBaseController
    {
        #region Portfolio Service Constructor

        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _portfolioService.GetPortfolioDataAsync());
        }

        public async Task<IActionResult> LoadPortfolioFormModalAsync(long id)
        {
            UpsertPortfolioViewModel portfolio = await _portfolioService.FillPortfolioAsync(id);

            return PartialView("Partials/_PortfolioFormModal", portfolio);
        }

        public async Task<IActionResult> SubmitPortfolioFormModalAsync(UpsertPortfolioViewModel portfolioViewModel)
        {
            bool result = await _portfolioService.UpsertPortfolioAsync(portfolioViewModel);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeletePortfolioAsync(long id)
        {
            bool result = await _portfolioService.DeletePortfolioAsync(id);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> UploadPortfolioImageAjaxAsync(IFormFile file)
        {
            if (file != null)
            {
                if (Path.GetExtension(file.FileName) == ".png" ||
                    Path.GetExtension(file.FileName) == ".jpeg" ||
                    Path.GetExtension(file.FileName) == ".jpg")
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(file.FileName);
                    await file.AddImageAjaxToServer(imageName, FilePaths.PortfolioServer);
                    return new JsonResult(new { status = "Success", imageName = imageName });
                }
                else
                {
                    return new JsonResult(new { status = "Error" });
                }
            }
            else
            {
                return new JsonResult(new { status = "Error" });
            }
        }
    }
}
