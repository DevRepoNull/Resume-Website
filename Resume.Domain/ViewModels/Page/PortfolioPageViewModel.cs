using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Domain.ViewModels.Page;

public class PortfolioPageViewModel
{
    public List<PortfolioViewModel> PortfolioList { get; set; }

    public List<PortfolioCategoryViewModel> PortfolioCategoryList { get; set; }
}