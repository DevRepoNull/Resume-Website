using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Application.ViewModels.CustomerFeedback;
using Resume.Application.Context;

namespace Resume.Application.Services.Implementations;

public class CustomerFeedBackService : ICustomerFeedBackService
{
    #region Customer Feedback Constructor

    private readonly IAppDbContext _IAppDbContext;

    public CustomerFeedBackService(IAppDbContext IAppDbContext)
    {
        _IAppDbContext = IAppDbContext;
    }

    #endregion

    public async Task<CustomerFeedback> GetCustomerFeedBackByIdAsync(long id)
    {
        return await _IAppDbContext.CustomerFeedbacks.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<List<CustomerFeedBackViewModel>> GetCustomerFeedBackForIndexAsync()
    {
        List<CustomerFeedBackViewModel> Data = await _IAppDbContext.CustomerFeedbacks
            .OrderBy(c => c.Order)
            .Select(c => new CustomerFeedBackViewModel()
            {
                Name = c.Name,
                Order = c.Order,
                Description = c.Description,
                Avatar = c.Avatar,
                Id = c.Id
            }).ToListAsync();

        return Data;
    }

    public async Task<UpsertCustomerFeedbackViewModel> FillUpsertCustomerFeedbackAsync(long id)
    {
        if (id == 0)
            return new UpsertCustomerFeedbackViewModel() { Id = 0 };

        CustomerFeedback customer = await GetCustomerFeedBackByIdAsync(id);

        if (customer == null)
            return new UpsertCustomerFeedbackViewModel() { Id = 0 };

        return new UpsertCustomerFeedbackViewModel()
        {
            Id = customer.Id,
            Name = customer.Name,
            Description = customer.Description,
            Avatar = customer.Avatar,
            Order = customer.Order
        };
    }

    public async Task<bool> UpsertCustomerFeedbackAsync(UpsertCustomerFeedbackViewModel customerFeedback)
    {
        if (customerFeedback.Id == 0)
        {
            var newCustomerFeedback = new CustomerFeedback()
            {
                Id = customerFeedback.Id,
                Name = customerFeedback.Name,
                Description = customerFeedback.Description,
                Avatar = customerFeedback.Avatar,
                Order = customerFeedback.Order
            };

            await _IAppDbContext.CustomerFeedbacks.AddAsync(newCustomerFeedback);
            await _IAppDbContext.SaveChangesAsync();
            return true;
        }

        CustomerFeedback currentCustomer = await GetCustomerFeedBackByIdAsync(customerFeedback.Id);

        if (currentCustomer == null) return false;

        currentCustomer.Avatar = currentCustomer.Avatar;
        currentCustomer.Name = currentCustomer.Name;
        currentCustomer.Description = currentCustomer.Description;
        currentCustomer.Order = currentCustomer.Order;

        _IAppDbContext.CustomerFeedbacks.Update(currentCustomer);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCustomerFeedbackAsync(long id)
    {
        if (id == 0) return false;

        CustomerFeedback customer = await GetCustomerFeedBackByIdAsync(id);
        if (customer == null) return false;

        _IAppDbContext.CustomerFeedbacks.Remove(customer);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }
}