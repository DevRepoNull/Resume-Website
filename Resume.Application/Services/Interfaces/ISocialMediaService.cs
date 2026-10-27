using Resume.Domain.Models;
using Resume.Application.ViewModels.SocialMedia;

namespace Resume.Application.Services.Interfaces;

public interface ISocialMediaService
{
    Task<SocialMedia> GetSocialMediaByIdAsync(long id);
    Task<List<SocialMediaViewModel>> GetSocialMediaDataAsync();
    Task<UpsertSocialMediaViewModel> FillSocialMediaAsync(long id);
    Task<bool> UpsertSocialMediaAsync(UpsertSocialMediaViewModel  socialMedia);
    Task<bool> DeleteSocialMediaAsync(long id);
}