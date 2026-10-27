using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Application.ViewModels.CustomerLogo;
using Resume.Application.Context;

namespace Resume.Application.Services.Implementations
{
    public class CustomerLogoService : ICustomerLogoService
    {
        #region Customer Logo Constructor

        private readonly IAppDbContext _IAppDbContext;

        public CustomerLogoService(IAppDbContext IAppDbContext)
        {
            _IAppDbContext = IAppDbContext;
        }

        #endregion

        public async Task<CustomerLogo> GetCustomerLogoByIdAsync(long id)
        {
            return await _IAppDbContext.CustomerLogos.FirstOrDefaultAsync(cl => cl.Id == id);
        }

        public async Task<List<CustomerLogoViewModel>> GetCustomerLogoDataForIndexAsync()
        {
            List<CustomerLogoViewModel> data = await _IAppDbContext.CustomerLogos
                .OrderBy(cl => cl.Order)
                .Select(cl => new CustomerLogoViewModel()
                {
                    Id = cl.Id,
                    Logo = cl.Logo,
                    LogoAlt = cl.LogoAlt,
                    Link = cl.Link,
                    Order = cl.Order
                }).ToListAsync();

            return data;
        }

        public async Task<UpsertCustomerLogoViewModel> FillCustomerLogoAsync(long id)
        {
            if (id == 0)
                return new UpsertCustomerLogoViewModel() { Id = 0 };

            CustomerLogo customerLogo = await GetCustomerLogoByIdAsync(id);

            if (customerLogo == null)
                return new UpsertCustomerLogoViewModel() { Id = 0 };

            return new UpsertCustomerLogoViewModel()
            {
                Id = customerLogo.Id,
                Logo = customerLogo.Logo,
                LogoAlt = customerLogo.LogoAlt,
                Link = customerLogo.Link,
                Order = customerLogo.Order
            };
        }

        public async Task<bool> UpsertCustomerLogoAsync(UpsertCustomerLogoViewModel customerLogo)
        {
            if (customerLogo.Id == 0)
            {
                CustomerLogo newCustomerLogo = new CustomerLogo()
                {
                    Logo = customerLogo.Logo,
                    LogoAlt = customerLogo.LogoAlt,
                    Link = customerLogo.Link,
                    Order = customerLogo.Order
                };

                await _IAppDbContext.CustomerLogos.AddAsync(newCustomerLogo);
                await _IAppDbContext.SaveChangesAsync();
                return true;
            }

            CustomerLogo currentCustomerLogo = await GetCustomerLogoByIdAsync(customerLogo.Id);

            if (currentCustomerLogo == null)
                return false;

            currentCustomerLogo.Logo = customerLogo.Logo;
            currentCustomerLogo.LogoAlt = customerLogo.LogoAlt;
            currentCustomerLogo.Link = customerLogo.Link;
            currentCustomerLogo.Order = customerLogo.Order;

            _IAppDbContext.CustomerLogos.Update(currentCustomerLogo);
            await _IAppDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomerLogoAsync(long id)
        {
            if (id == 0)
                return false;

            CustomerLogo result = await GetCustomerLogoByIdAsync(id);

            if (result == null)
                return false;

            _IAppDbContext.CustomerLogos.Remove(result);
            await _IAppDbContext.SaveChangesAsync();
            return true;
        }
    }
}