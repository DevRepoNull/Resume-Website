using Resume.Application.ViewModels.CustomerFeedback;
using Resume.Application.ViewModels.CustomerLogo;
using Resume.Application.ViewModels.Experience;
using Resume.Application.ViewModels.Information;
using Resume.Application.ViewModels.ThingIDo;

namespace Resume.Application.ViewModels.Page;

public class IndexPageViewModel
{
    public InformationViewModel Information { get; set; }

    public List<ExperienceViewModel> ExperienceList { get; set; }

    public List<ThingIDoViewModel> ThingIDoList { get; set; }

    public List<CustomerFeedBackViewModel> CustomerFeedbackList { get; set; }

    public List<CustomerLogoViewModel> CustomerLogoList { get; set; }
}
