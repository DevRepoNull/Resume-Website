using Resume.Domain.Models;
using Resume.Domain.ViewModels.Information;

namespace Resume.Application.Services.Interfaces;

public interface IInformationService
{
    Task<InformationViewModel> GetInformationDataAsync();

    Task<Information> GetInformationModelAsync();

    Task<UpsertInformationViewModel> FillUpsertInformationViewModelAsync();

    Task<bool> UpsertInformationAsync(UpsertInformationViewModel upsertInformationViewModel);
}