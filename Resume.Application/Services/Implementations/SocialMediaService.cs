using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Application.ViewModels.SocialMedia;
using Resume.Application.Context;

namespace Resume.Application.Services.Implementations;

public class SocialMediaService : ISocialMediaService
{
    #region Social Media Service

    private readonly IAppDbContext _IAppDbContext;

    public SocialMediaService(IAppDbContext IAppDbContext)
    {
        _IAppDbContext = IAppDbContext;
    }

    #endregion

    public async Task<SocialMedia> GetSocialMediaByIdAsync(long id)
    {
        return await _IAppDbContext.SocialMedias.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<SocialMediaViewModel>> GetSocialMediaDataAsync()
    {
        List<SocialMediaViewModel> model = await _IAppDbContext.SocialMedias
            .OrderBy(s => s.Order)
            .Select(s => new SocialMediaViewModel()
            {
                Id = s.Id,
                Icon = s.Icon,
                Link = s.Link,
                Order = s.Order
            }).ToListAsync();
        
        return model;
    }

    public async Task<UpsertSocialMediaViewModel> FillSocialMediaAsync(long id)
    {
        if (id == 0)
            return new UpsertSocialMediaViewModel() { Id = 0 };

        SocialMedia socialMedia = await GetSocialMediaByIdAsync(id);

        if (socialMedia == null)
            return new UpsertSocialMediaViewModel() { Id = 0 };

        return new UpsertSocialMediaViewModel()
        {
            Id = socialMedia.Id,
            Icon = socialMedia.Icon,
            Link = socialMedia.Link,
            Order = socialMedia.Order
        };
    }

    public async Task<bool> UpsertSocialMediaAsync(UpsertSocialMediaViewModel socialMedia)
    {
        if (socialMedia.Id == 0)
        {
            SocialMedia newSocialMedia = new SocialMedia()
            {
                Icon = socialMedia.Icon,
                Link = socialMedia.Link,
                Order = socialMedia.Order
            };

            await _IAppDbContext.SocialMedias.AddAsync(newSocialMedia);
            await _IAppDbContext.SaveChangesAsync();
            return true;
        }

        SocialMedia currentSocialMedia = await GetSocialMediaByIdAsync(socialMedia.Id);

        if (currentSocialMedia == null)
            return false;

        currentSocialMedia.Icon = socialMedia.Icon;
        currentSocialMedia.Link = socialMedia.Link;
        currentSocialMedia.Order = socialMedia.Order;

        _IAppDbContext.SocialMedias.Update(currentSocialMedia);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteSocialMediaAsync(long id)
    {
        if (id == 0)
            return false;

        SocialMedia currentSocialMedia = await GetSocialMediaByIdAsync(id);

        if (currentSocialMedia == null)
            return false;

        _IAppDbContext.SocialMedias.Remove(currentSocialMedia);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }
}