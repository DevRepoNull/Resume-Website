using Resume.Domain.Models;
using Resume.Domain.ViewModels.Portfolio;

namespace Resume.Application.Services.Interfaces;

public interface IPortfolioService
{
    #region Portfolio

    Task<Portfolio> GetPortfolioByIdAsync(long id);

    Task<List<PortfolioViewModel>> GetPortfolioDataAsync();

    Task<UpsertPortfolioViewModel> FillPortfolioAsync(long id);

    Task<bool> UpsertPortfolioAsync(UpsertPortfolioViewModel portfolio);

    Task<bool> DeletePortfolioAsync(long id);

    #endregion

    #region Portfolio Category

    Task<PortfolioCategory> GetPortfolioCategoryByIdAsync(long id);
    Task<List<PortfolioCategoryViewModel>> GetPortfolioCategoryDataAsync();
    Task<UpsertPortfolioCategoryViewModel> FillUpsertPortfolioCategoryAsync(long id);
    Task<bool> UpsertPortfolioCategoryAsync(UpsertPortfolioCategoryViewModel  portfolioCategory);
    Task<bool> DeletePortfolioCategoryAsync(long id);

    #endregion
}