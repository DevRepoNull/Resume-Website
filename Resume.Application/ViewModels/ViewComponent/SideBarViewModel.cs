using Resume.Application.ViewModels.Information;
using Resume.Application.ViewModels.SocialMedia;

namespace Resume.Application.ViewModels.ViewComponent;

public class SideBarViewModel
{
    public List<SocialMediaViewModel> SocialMediaList { get; set; }

    public InformationViewModel InformationData { get; set; }
}