using Resume.Domain.Models;
using Resume.Domain.ViewModels.Experience;

namespace Resume.Application.Services.Interfaces;

public interface IExperienceService
{
    Task<Experience> GetExperienceByIdAsync(long id);
    Task<List<ExperienceViewModel>> GetExperienceDataListAsync();
    Task<UpsertExperienceViewModel> FillUpsertExperienceAsync(long id);
    Task<bool> UpsertExperienceAsync(UpsertExperienceViewModel  experience);
    Task<bool> DeleteExperienceAsync(long id);
}