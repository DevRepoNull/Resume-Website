using Resume.Application.ViewModels.Portfolio;

namespace Resume.Application.ViewModels.Page;

public class PortfolioPageViewModel
{
    public List<PortfolioViewModel> PortfolioList { get; set; }

    public List<PortfolioCategoryViewModel> PortfolioCategoryList { get; set; }
}