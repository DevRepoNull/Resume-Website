using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Information;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations;

public class InformationService : IInformationService
{
    #region Information Constructor

    private readonly AppDbContext _appDbContext;

    public InformationService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #endregion

    // Target : We wanna to have a single information this site because we create resume web sties

    public async Task<InformationViewModel> GetInformationDataAsync()
    {
        // if (information == null)
        // {
        //     return new InformationViewModel();
        // }

        try
        {
            InformationViewModel data = await _appDbContext.Informations
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
                    MapSrc = info.MapSrc
                }).FirstOrDefaultAsync() ?? new InformationViewModel();

            return data;
        }
        catch
        {
            //throw new Exception(e.Message);
            return new InformationViewModel();
        }
    }

    public async Task<Information> GetInformationModelAsync()
    {
        return await _appDbContext.Informations.FirstOrDefaultAsync();
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
            MapSrc = information.MapSrc
        };
    }

    public async Task<bool> UpsertInformationAsync(UpsertInformationViewModel information)
    {
        if (information.Id == 0)
        {
            Information newInformation = new Information()
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
                MapSrc = information.MapSrc
            };

            await _appDbContext.Informations.AddAsync(newInformation);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        Information currentInformation = await GetInformationModelAsync();

        currentInformation.Id = information.Id;
        currentInformation.Name = information.Name;
        currentInformation.Address = information.Address;
        currentInformation.Avatar = information.Avatar;
        currentInformation.DateOfBirth = information.DateOfBirth;
        currentInformation.EmailAddress = information.EmailAddress;
        currentInformation.Job = information.Job;
        currentInformation.PhoeNumber = information.PhoeNumber;
        currentInformation.ResumeFile = information.ResumeFile;
        currentInformation.MapSrc = information.MapSrc;

        _appDbContext.Informations.Update(currentInformation);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}