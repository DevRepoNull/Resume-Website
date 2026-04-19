using Resume.Domain.Models;
using Resume.Domain.ViewModels.Skill;

namespace Resume.Application.Services.Interfaces;

public interface ISkillService
{
    Task<Skill> GetSkillByIdAsync(long id);
    Task<List<SkillViewModel>> GetSkillDataAsync();
    Task<UpsertSkillViewModel> FillUpsertSkillViewModel(long id);
    Task<bool> UpsertSkillAsync(UpsertSkillViewModel skill);
    Task<bool> DeleteSkillAsync(long id);
}