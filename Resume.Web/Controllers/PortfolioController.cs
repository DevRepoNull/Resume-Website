using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;

namespace Resume.Web.Controllers
{
    public class PortfolioController : Controller
    {
        #region Portfolio Constructor

        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            PortfolioPageViewModel model = new PortfolioPageViewModel()
            {
                PortfolioList = await _portfolioService.GetPortfolioDataAsync(),
                PortfolioCategoryList = await _portfolioService.GetPortfolioCategoryDataAsync()
            };
            return View(model);
        }
    }
}