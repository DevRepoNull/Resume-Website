using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Domain.ViewModels.CustomerLogo;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Domain.ViewModels.Page;

public class IndexPageViewModel
{
    public List<ThingIDoViewModel> ThingIDoList { get; set; }

    public List<CustomerFeedBackViewModel> CustomerFeedbackList { get; set; }

    public List<CustomerLogoViewModel> CustomerLogoList { get; set; }
}