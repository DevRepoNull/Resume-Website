using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Web.Areas.Admin.Controllers
{
    public class PortfolioCategoryController : AdminBaseController
    {
        #region Constructor

        private IPortfolioService _portfolioService;

        public PortfolioCategoryController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _portfolioService.GetPortfolioCategoryDataAsync());
        }

        public async Task<IActionResult> LoadPortfolioCategoryFormModalAsync(long id)
        {
            UpsertPortfolioCategoryViewModel result = await _portfolioService.FillUpsertPortfolioCategoryAsync(id);

            return PartialView("Partials/_PortfolioCategoryFormModal", result);
        }

        public async Task<IActionResult> SubmitPortfolioCategoryFormAsync(
            UpsertPortfolioCategoryViewModel portfolioCategory)
        {
            var result = await _portfolioService.UpsertPortfolioCategoryAsync(portfolioCategory);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }

        public async Task<IActionResult> DeletePortfolioCategoryAsync(long id)
        {
            var result = await _portfolioService.DeletePortfolioCategoryAsync(id);

            if (result)
                return new JsonResult(new { status = "Success" });

            return new JsonResult(new { status = "Error" });
        }
    }
}
