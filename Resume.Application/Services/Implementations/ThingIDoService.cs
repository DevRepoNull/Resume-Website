using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.ThingIDo;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations;

public class ThingIDoService : IThingIDoService
{
    // Constructor Dependencies
    private readonly AppDbContext _appDb;

    public ThingIDoService(AppDbContext appDb)
    {
        _appDb = appDb;
    }

    public async Task<ThingIDo> GetThingIDoById(long id)
    {
        return await _appDb.ThingIDos.FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<List<ThingIDoViewModel>> GetAllThingIDoDataAsync()
    {
        List<ThingIDoViewModel> combinedData = await _appDb.ThingIDos
            .OrderBy(t => t.Order)
            .Select(t => new ThingIDoViewModel()
            {
                Id = t.Id,
                ColumnLg = t.ColumnLg,
                Order = t.Order,
                Description = t.Description,
                Icon = t.Icon,
                Title = t.Title
            }).ToListAsync();

        return combinedData;
    }

    public async Task<bool> CreateOrEditThingIDo(CreateOrEditThingIDoViewModel thingIDo)
    {
        if (thingIDo.Id == 0)
        {
            // Create
            var newThingIDo = new ThingIDo()
            {
                ColumnLg = thingIDo.ColumnLg,
                Title = thingIDo.Title,
                Order = thingIDo.Order,
                Icon = thingIDo.Icon,
                Description = thingIDo.Description
            };

            await _appDb.ThingIDos.AddAsync(newThingIDo);
            await _appDb.SaveChangesAsync();
            return true;
        }

        // Edit
        ThingIDo currentThingIdo = await GetThingIDoById(thingIDo.Id);

        if (currentThingIdo == null) return false;

        currentThingIdo.Title = thingIDo.Title;
        currentThingIdo.ColumnLg = thingIDo.ColumnLg;
        currentThingIdo.Description = thingIDo.Description;
        currentThingIdo.Icon = thingIDo.Icon;
        currentThingIdo.Order = thingIDo.Order;

        _appDb.ThingIDos.Update(currentThingIdo);
        await _appDb.SaveChangesAsync();
        return true;
    }

    public async Task<CreateOrEditThingIDoViewModel> FillUpsertThingIDoViewModelAsync(long id)
    {
        if (id == 0) return new CreateOrEditThingIDoViewModel() { Id = 0 };

        ThingIDo thingIDo = await GetThingIDoById(id);

        if (thingIDo == null) return new CreateOrEditThingIDoViewModel() { Id = 0 };

        return new CreateOrEditThingIDoViewModel()
        {
            Id = thingIDo.Id,
            ColumnLg = thingIDo.ColumnLg,
            Description = thingIDo.Description,
            Icon = thingIDo.Icon,
            Order = thingIDo.Order,
            Title = thingIDo.Title
        };
    }

    public async Task<bool> DeleteThingIDoAsync(long id)
    {
        ThingIDo model = await GetThingIDoById(id);

        if (model == null) 
            return false;

        _appDb.ThingIDos.Remove(model);
        await _appDb.SaveChangesAsync();

        return true;
    }
}