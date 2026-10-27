using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Application.ViewModels.Page;

namespace Resume.Web.Controllers;

public class HomeController : Controller
{
    #region Constructor

    private readonly IThingIDoService _doService;
    private readonly ICustomerFeedBackService _customerFeedBackService;
    private readonly ICustomerLogoService _customerLogo;
    private readonly IInformationService _informationService;
    private readonly IExperienceService _experienceService;

    public HomeController(
        IThingIDoService doService,
        ICustomerFeedBackService customerFeedBackService,
        ICustomerLogoService customerLogo,
        IInformationService informationService,
        IExperienceService experienceService)
    {
        _doService = doService;
        _customerFeedBackService = customerFeedBackService;
        _customerLogo = customerLogo;
        _informationService = informationService;
        _experienceService = experienceService;
    }

    #endregion

    public async Task<IActionResult> Index()
    {
        IndexPageViewModel page = new IndexPageViewModel()
        {
            Information = await _informationService.GetInformationDataAsync(),
            ExperienceList = await _experienceService.GetExperienceDataListAsync(),
            ThingIDoList = await _doService.GetAllThingIDoDataAsync(),
            CustomerFeedbackList = await _customerFeedBackService.GetCustomerFeedBackForIndexAsync(),
            CustomerLogoList = await _customerLogo.GetCustomerLogoDataForIndexAsync()
        };

        return View(page);
    }
}
