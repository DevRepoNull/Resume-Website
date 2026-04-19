using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.Page;

namespace Resume.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Constructor

        private readonly IThingIDoService _doService;

        private readonly ICustomerFeedBackService _customerFeedBackService;

        private readonly ICustomerLogoService _customerLogo;

        public HomeController(IThingIDoService doService, ICustomerFeedBackService customerFeedBackService, ICustomerLogoService customerLogo)
        {
            _doService = doService;
            _customerFeedBackService = customerFeedBackService;
            _customerLogo = customerLogo;
        }

        #endregion

        public async Task<IActionResult> Index()
        {
            IndexPageViewModel page = new IndexPageViewModel()
            {
                ThingIDoList = await _doService.GetAllThingIDoDataAsync(),
                CustomerFeedbackList = await _customerFeedBackService.GetCustomerFeedBackForIndexAsync(),
                CustomerLogoList = await _customerLogo.GetCustomerLogoDataForIndexAsync()
            };

            return View(page);
        }
    }
}
