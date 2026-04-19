using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerLogo;

namespace Resume.Application.Services.Interfaces;

public interface ICustomerLogoService
{
    Task<CustomerLogo> GetCustomerLogoByIdAsync(long id);

    Task<List<CustomerLogoViewModel>> GetCustomerLogoDataForIndexAsync();

    Task<UpsertCustomerLogoViewModel> FillCustomerLogoAsync(long id);

    Task<bool> UpsertCustomerLogoAsync(UpsertCustomerLogoViewModel  customerLogo);

    Task<bool> DeleteCustomerLogoAsync(long id);
}