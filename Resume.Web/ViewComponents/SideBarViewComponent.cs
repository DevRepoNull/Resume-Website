using Microsoft.AspNetCore.Mvc;
using Resume.Application.Services.Interfaces;
using Resume.Domain.ViewModels.ViewComponent;

namespace Resume.Web.ViewComponents;

public class SideBarViewComponent : ViewComponent
{
    #region Sidebar Constructor

    private readonly ISocialMediaService _mediaService;

    private readonly IInformationService _informationService;

    public SideBarViewComponent(ISocialMediaService mediaService, IInformationService informationService)
    {
        _mediaService = mediaService;
        _informationService = informationService;
    }

    #endregion

    public async Task<IViewComponentResult> InvokeAsync()
    {
        SideBarViewModel model = new SideBarViewModel()
        {
            SocialMediaList = await _mediaService.GetSocialMediaDataAsync(),
            InformationData = await _informationService.GetInformationDataAsync()
        };
        
        return View("SideBar", model);
    }
}