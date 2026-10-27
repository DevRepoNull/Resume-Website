using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Application.ViewModels.Portfolio;
using Resume.Application.Context;

namespace Resume.Application.Services.Implementations;

public class PortfolioService : IPortfolioService
{
    #region Portfolio Constructor

    private readonly IAppDbContext _IAppDbContext;

    public PortfolioService(IAppDbContext IAppDbContext)
    {
        _IAppDbContext = IAppDbContext;
    }

    #endregion

    #region Portfolio

    public async Task<Portfolio> GetPortfolioByIdAsync(long id)
    {
        return await _IAppDbContext.Portfolios.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<PortfolioViewModel>> GetPortfolioDataAsync()
    {
        List<PortfolioViewModel> model = await _IAppDbContext.Portfolios
            .OrderBy(p => p.Order)
            .Select(p => new PortfolioViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Image = p.Image,
                Link = p.Link,
                AltImage = p.AltImage,
                Order = p.Order,
                PortfolioCategoryLatinTitle = p.PortfolioCategory.LatinTitle
            }).ToListAsync();

        return model;
    }

    public async Task<UpsertPortfolioViewModel> FillPortfolioAsync(long id)
    {
        var categories = await GetPortfolioCategoryDataAsync();

        if (id == 0)
            return new UpsertPortfolioViewModel()
            {
                Id = 0,
                PortfolioCategory = categories
            };

        Portfolio portfolio = await GetPortfolioByIdAsync(id);

        if (portfolio == null)
            return new UpsertPortfolioViewModel()
            {
                Id = 0,
                PortfolioCategory = categories
            };

        return new UpsertPortfolioViewModel()
        {
            Id = portfolio.Id,
            Image = portfolio.Image,
            AltImage = portfolio.AltImage,
            Link = portfolio.Link,
            Title = portfolio.Title,
            PortfolioCategoryId = portfolio.PortfolioCategoryId,
            PortfolioCategory = categories
        };
    }

    public async Task<bool> UpsertPortfolioAsync(UpsertPortfolioViewModel portfolio)
    {
        if (portfolio.Id == 0)
        {
            Portfolio newPortfolio = new Portfolio()
            {
                Title = portfolio.Title,
                Image = portfolio.Image,
                AltImage = portfolio.AltImage,
                Link = portfolio.Link,
                Order = portfolio.Order,
                PortfolioCategoryId = portfolio.PortfolioCategoryId
            };

            await _IAppDbContext.Portfolios.AddAsync(newPortfolio);
            await _IAppDbContext.SaveChangesAsync();
            return true;
        }

        Portfolio currentPortfolio = await GetPortfolioByIdAsync(portfolio.Id);

        currentPortfolio.Title = portfolio.Title;
        currentPortfolio.Image = portfolio.Image;
        currentPortfolio.AltImage = portfolio.AltImage;
        currentPortfolio.Link = portfolio.Link;
        currentPortfolio.Order = portfolio.Order;
        currentPortfolio.PortfolioCategoryId = portfolio.PortfolioCategoryId;

        _IAppDbContext.Portfolios.Update(currentPortfolio);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePortfolioAsync(long id)
    {
        if (id == 0)
            return false;

        Portfolio currentPortfolio = await GetPortfolioByIdAsync(id);

        if (currentPortfolio == null)
            return false;

        _IAppDbContext.Portfolios.Remove(currentPortfolio);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }

    #endregion

    #region Portfolio Category

    public async Task<PortfolioCategory> GetPortfolioCategoryByIdAsync(long id)
    {
        return await _IAppDbContext.PortfolioCategories.FirstOrDefaultAsync(pc => pc.Id == id);
    }

    public async Task<List<PortfolioCategoryViewModel>> GetPortfolioCategoryDataAsync()
    {
        List<PortfolioCategoryViewModel> model = await _IAppDbContext.PortfolioCategories
            .OrderBy(pc => pc.Order)
            .Select(pc => new PortfolioCategoryViewModel()
            {
                Id = pc.Id,
                Order = pc.Order,
                Title = pc.Title,
                LatinTitle = pc.LatinTitle
            }).ToListAsync();

        return model;
    }

    public async Task<UpsertPortfolioCategoryViewModel> FillUpsertPortfolioCategoryAsync(long id)
    {
        if (id == 0)
            return new UpsertPortfolioCategoryViewModel() { Id = 0 };

        PortfolioCategory portfolioCategory = await GetPortfolioCategoryByIdAsync(id);

        if (portfolioCategory == null)
            return new UpsertPortfolioCategoryViewModel() { Id = 0 };

        return new UpsertPortfolioCategoryViewModel()
        {
            Id = portfolioCategory.Id,
            Title = portfolioCategory.Title,
            LatinTitle = portfolioCategory.LatinTitle,
            Order = portfolioCategory.Order
        };
    }

    public async Task<bool> UpsertPortfolioCategoryAsync(UpsertPortfolioCategoryViewModel portfolioCategory)
    {
        if (portfolioCategory.Id == 0)
        {
            PortfolioCategory newPortfolioCategory = new PortfolioCategory()
            {
                Title = portfolioCategory.Title,
                LatinTitle = portfolioCategory.LatinTitle,
                Order = portfolioCategory.Order
            };

            await _IAppDbContext.PortfolioCategories.AddAsync(newPortfolioCategory);
            await _IAppDbContext.SaveChangesAsync();
            return true;
        }

        PortfolioCategory currentPortfolioCategory = await GetPortfolioCategoryByIdAsync(portfolioCategory.Id);

        if (currentPortfolioCategory == null)
            return false;

        currentPortfolioCategory.Title = portfolioCategory.Title;
        currentPortfolioCategory.LatinTitle = portfolioCategory.LatinTitle;
        currentPortfolioCategory.Order = portfolioCategory.Order;

        _IAppDbContext.PortfolioCategories.Update(currentPortfolioCategory);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePortfolioCategoryAsync(long id)
    {
        PortfolioCategory portfolioCategory = await GetPortfolioCategoryByIdAsync(id);

        if (portfolioCategory == null)
            return false;

        _IAppDbContext.PortfolioCategories.Remove(portfolioCategory);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }

    #endregion
}