using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Education;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations;

public class EducationService : IEducationService
{
    #region Education Constructor

    private readonly AppDbContext _appDbContext;

    public EducationService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #endregion

    public async Task<Education> GetEducationByIdAsync(long id)
    {
        return await _appDbContext.Educations.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<EducationViewModel>> GetEducationDataListAsync()
    {
        List<EducationViewModel> model = await _appDbContext.Educations.OrderBy(e => e.Order)
            .Select(e => new EducationViewModel()
            {
                Order = e.Order,
                Description = e.Description,
                EndDate = e.EndDate,
                StartDate = e.StartDate,
                Title = e.Title,
                Id = e.Id
            }).ToListAsync();

        return model;
    }

    public async Task<UpsertEducationViewModel> FillUpsertEducationViewModelAsync(long id)
    {
        if (id == 0)
            return new UpsertEducationViewModel() { Id = 0};

        Education education = await GetEducationByIdAsync(id);

        if (education == null)
            return new UpsertEducationViewModel() { Id = 0 };

        return new UpsertEducationViewModel()
        {
            Id = education.Id,
            Description = education.Description,
            EndDate = education.EndDate,
            Order = education.Order,
            StartDate = education.StartDate,
            Title = education.Title
        };
    }

    public async Task<bool> UpsertEducationAsync(UpsertEducationViewModel education)
    {
        if (education.Id == 0)
        {
            Education newEducation = new Education()
            {
                Title = education.Title,
                Description = education.Description,
                StartDate = education.StartDate,
                EndDate = education.EndDate,
                Order = education.Order
            };

            await _appDbContext.Educations.AddAsync(newEducation);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        Education updateEducation = await GetEducationByIdAsync(education.Id);

        if (updateEducation == null)
            return false;

        updateEducation.Title = education.Title;
        updateEducation.Description = education.Description;
        updateEducation.StartDate = education.StartDate;
        updateEducation.EndDate = education.EndDate;
        updateEducation.Order = education.Order;

        _appDbContext.Update(updateEducation);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEducationAsync(long id)
    {
        Education education = await GetEducationByIdAsync(id);

        if (education == null)
            return false;

        _appDbContext.Educations.Remove(education);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}