using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Experience;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations;

public class ExperienceService : IExperienceService
{
    #region Experience Constructor

    private readonly AppDbContext _dbContext;

    public ExperienceService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    #endregion

    public async Task<Experience> GetExperienceByIdAsync(long id)
    {
        return await _dbContext.Experiences.FirstOrDefaultAsync(ex => ex.Id == id);
    }

    public async Task<List<ExperienceViewModel>> GetExperienceDataListAsync()
    {
        List<ExperienceViewModel> model = await _dbContext.Experiences
            .OrderBy(ep => ep.Order)
            .Select(ep => new ExperienceViewModel()
            {
                Order = ep.Order,
                Description = ep.Description,
                StartDate = ep.StartDate,
                EndDate = ep.EndDate,
                Title = ep.Title,
                Id = ep.Id
            }).ToListAsync();

        return model;
    }

    public async Task<UpsertExperienceViewModel> FillUpsertExperienceAsync(long id)
    {
        if (id == 0)
            return new UpsertExperienceViewModel() { Id = 0 };

        Experience experience = await GetExperienceByIdAsync(id);

        if (experience == null)
            return new UpsertExperienceViewModel() { Id = 0 };

        return new UpsertExperienceViewModel()
        {
            Id = experience.Id,
            Title = experience.Title,
            Description = experience.Description,
            StartDate = experience.StartDate,
            EndDate = experience.EndDate,
            Order = experience.Order
        };
    }

    public async Task<bool> UpsertExperienceAsync(UpsertExperienceViewModel experience)
    {
        if (experience.Id == 0)
        {
            Experience newExperience = new Experience()
            {
                Title = experience.Title,
                Description = experience.Description,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate,
                Order = experience.Order
            };
            await _dbContext.Experiences.AddAsync(newExperience);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        Experience updateExperience = await GetExperienceByIdAsync(experience.Id);

        if (updateExperience == null)
            return false;

        updateExperience.Title = experience.Title;
        updateExperience.Description = experience.Description;
        updateExperience.StartDate = experience.StartDate;
        updateExperience.EndDate = experience.EndDate;
        updateExperience.Order = experience.Order;

        _dbContext.Experiences.Update(updateExperience);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteExperienceAsync(long id)
    {
        Experience delExperience = await GetExperienceByIdAsync(id);

        if (delExperience == null)
            return false;

        _dbContext.Experiences.Remove(delExperience);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}