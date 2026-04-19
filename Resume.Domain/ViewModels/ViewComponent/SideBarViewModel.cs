using Resume.Domain.ViewModels.Information;
using Resume.Domain.ViewModels.SocialMedia;

namespace Resume.Domain.ViewModels.ViewComponent;

public class SideBarViewModel
{
    public List<SocialMediaViewModel> SocialMediaList { get; set; }

    public InformationViewModel InformationData { get; set; }
}