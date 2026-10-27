using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Application.ViewModels.Information;
using Resume.Application.Context;

namespace Resume.Application.Services.Implementations;

public class InformationService : IInformationService
{
    #region Information Constructor

    private readonly IAppDbContext _IAppDbContext;

    public InformationService(IAppDbContext IAppDbContext)
    {
        _IAppDbContext = IAppDbContext;
    }

    #endregion

    public async Task<InformationViewModel> GetInformationDataAsync()
    {
        try
        {
            InformationViewModel data = await _IAppDbContext.Informations
                .Select(info => new InformationViewModel()
                {
                    Id = info.Id,
                    Name = info.Name,
                    Address = info.Address,
                    Avatar = info.Avatar,
                    DateOfBirth = info.DateOfBirth,
                    EmailAddress = info.EmailAddress,
                    Job = info.Job,
                    PhoeNumber = info.PhoeNumber,
                    ResumeFile = info.ResumeFile,
                    MapSrc = info.MapSrc,
                    AboutMe = info.AboutMe
                }).FirstOrDefaultAsync() ?? new InformationViewModel();

            return data;
        }
        catch
        {
            return new InformationViewModel();
        }
    }

    public async Task<Information> GetInformationModelAsync()
    {
        return await _IAppDbContext.Informations.FirstOrDefaultAsync();
    }

    public async Task<UpsertInformationViewModel> FillUpsertInformationViewModelAsync()
    {
        Information information = await GetInformationModelAsync();

        if (information == null)
            return new UpsertInformationViewModel() { Id = 0 };

        return new UpsertInformationViewModel()
        {
            Id = information.Id,
            Name = information.Name,
            Address = information.Address,
            Avatar = information.Avatar,
            DateOfBirth = information.DateOfBirth,
            EmailAddress = information.EmailAddress,
            Job = information.Job,
            PhoeNumber = information.PhoeNumber,
            ResumeFile = information.ResumeFile,
            MapSrc = information.MapSrc,
            AboutMe = information.AboutMe
        };
    }

    public async Task<bool> UpsertInformationAsync(UpsertInformationViewModel information)
    {
        Information currentInformation = await GetInformationModelAsync();

        if (currentInformation == null)
        {
            currentInformation = new Information
            {
                Name = information.Name,
                Address = information.Address,
                Avatar = information.Avatar,
                DateOfBirth = information.DateOfBirth,
                EmailAddress = information.EmailAddress,
                Job = information.Job,
                PhoeNumber = information.PhoeNumber,
                ResumeFile = information.ResumeFile,
                MapSrc = information.MapSrc,
                AboutMe = information.AboutMe
            };

            await _IAppDbContext.Informations.AddAsync(currentInformation);
        }
        else
        {
            currentInformation.Name = information.Name;
            currentInformation.Address = information.Address;
            currentInformation.Avatar = information.Avatar;
            currentInformation.DateOfBirth = information.DateOfBirth;
            currentInformation.EmailAddress = information.EmailAddress;
            currentInformation.Job = information.Job;
            currentInformation.PhoeNumber = information.PhoeNumber;
            currentInformation.ResumeFile = information.ResumeFile;
            currentInformation.MapSrc = information.MapSrc;
            currentInformation.AboutMe = information.AboutMe;

            _IAppDbContext.Informations.Update(currentInformation);
        }

        await _IAppDbContext.SaveChangesAsync();
        return true;
    }
}
