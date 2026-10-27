using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Application.ViewModels.Education;
using Resume.Application.Context;

namespace Resume.Application.Services.Implementations;

public class EducationService : IEducationService
{
    #region Education Constructor

    private readonly IAppDbContext _IAppDbContext;

    public EducationService(IAppDbContext IAppDbContext)
    {
        _IAppDbContext = IAppDbContext;
    }

    #endregion

    public async Task<Education> GetEducationByIdAsync(long id)
    {
        return await _IAppDbContext.Educations.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<EducationViewModel>> GetEducationDataListAsync()
    {
        List<EducationViewModel> model = await _IAppDbContext.Educations.OrderBy(e => e.Order)
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

            await _IAppDbContext.Educations.AddAsync(newEducation);
            await _IAppDbContext.SaveChangesAsync();
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

        _IAppDbContext.Educations.Update(updateEducation);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEducationAsync(long id)
    {
        Education education = await GetEducationByIdAsync(id);

        if (education == null)
            return false;

        _IAppDbContext.Educations.Remove(education);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }
}