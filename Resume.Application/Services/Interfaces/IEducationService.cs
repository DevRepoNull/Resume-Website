using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;

namespace Resume.Application.Services.Interfaces;

public interface IEducationService
{
    Task<Education> GetEducationByIdAsync(long id);

    Task<List<EducationViewModel>> GetEducationDataListAsync();

    Task<UpsertEducationViewModel> FillUpsertEducationViewModelAsync(long id);

    Task<bool> UpsertEducationAsync(UpsertEducationViewModel education);

    Task<bool> DeleteEducationAsync(long id);
}