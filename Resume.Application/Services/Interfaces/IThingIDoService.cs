using Resume.Domain.Models;
using Resume.Domain.ViewModels.ThingIDo;

namespace Resume.Application.Services.Interfaces;

public interface IThingIDoService
{
    Task<ThingIDo> GetThingIDoById(long id);
    Task<List<ThingIDoViewModel>> GetAllThingIDoDataAsync();
    Task<bool> CreateOrEditThingIDo(CreateOrEditThingIDoViewModel thingIDo);
    Task<CreateOrEditThingIDoViewModel> FillUpsertThingIDoViewModelAsync(long id);
    Task<bool> DeleteThingIDoAsync(long id);
}