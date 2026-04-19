using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Skill;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations;

public class SkillService : ISkillService
{
    #region Skill Constructor

    private readonly AppDbContext _appDbContext;

    public SkillService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #endregion

    public async Task<Skill> GetSkillByIdAsync(long id)
    {
        return await _appDbContext.Skills.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<SkillViewModel>> GetSkillDataAsync()
    {
        List<SkillViewModel> model = await _appDbContext.Skills
            .OrderBy(s => s.Order)
            .Select(s => new SkillViewModel()
            {
                Id = s.Id,
                Title = s.Title,
                Percentage = s.Percentage,
                Order = s.Order
            }).ToListAsync();

        return model;
    }

    public async Task<UpsertSkillViewModel> FillUpsertSkillViewModel(long id)
    {
        if (id == 0)
            return new UpsertSkillViewModel() { Id = 0 };

        Skill skillData = await GetSkillByIdAsync(id);

        if (skillData == null)
            return new UpsertSkillViewModel() { Id = 0 };

        return new UpsertSkillViewModel()
        {
            Id = skillData.Id,
            Title = skillData.Title,
            Percentage = skillData.Percentage,
            Order = skillData.Order
        };
    }

    public async Task<bool> UpsertSkillAsync(UpsertSkillViewModel skill)
    {
        if (skill.Id == 0)
        {
            Skill newSkill = new Skill()
            {
                Title = skill.Title,
                Percentage = skill.Percentage,
                Order = skill.Order
            };
            await _appDbContext.Skills.AddAsync(newSkill);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        Skill updateSkill = await GetSkillByIdAsync(skill.Id);

        updateSkill.Title = skill.Title;
        updateSkill.Percentage = skill.Percentage;
        updateSkill.Order = skill.Order;

        _appDbContext.Skills.Update(updateSkill);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteSkillAsync(long id)
    {
        Skill delSkill = await  GetSkillByIdAsync(id);

        if (delSkill == null)
            return false;

        _appDbContext.Skills.Remove(delSkill);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}