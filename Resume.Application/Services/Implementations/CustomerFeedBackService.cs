using Microsoft.EntityFrameworkCore;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.CustomerFeedback;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations;

public class CustomerFeedBackService : ICustomerFeedBackService
{
    #region Customer Feedback Constructor

    private readonly AppDbContext _appDbContext;

    public CustomerFeedBackService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #endregion

    public async Task<CustomerFeedback> GetCustomerFeedBackByIdAsync(long id)
    {
        return await _appDbContext.CustomerFeedbacks.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<List<CustomerFeedBackViewModel>> GetCustomerFeedBackForIndexAsync()
    {
        List<CustomerFeedBackViewModel> Data = await _appDbContext.CustomerFeedbacks
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

            await _appDbContext.CustomerFeedbacks.AddAsync(newCustomerFeedback);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        CustomerFeedback currentCustomer = await GetCustomerFeedBackByIdAsync(customerFeedback.Id);

        if (currentCustomer == null) return false;

        currentCustomer.Avatar = currentCustomer.Avatar;
        currentCustomer.Name = currentCustomer.Name;
        currentCustomer.Description = currentCustomer.Description;
        currentCustomer.Order = currentCustomer.Order;

        _appDbContext.CustomerFeedbacks.Update(currentCustomer);
        await _appDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCustomerFeedbackAsync(long id)
    {
        if (id == 0) return false;

        CustomerFeedback customer = await GetCustomerFeedBackByIdAsync(id);
        if (customer == null) return false;

        _appDbContext.CustomerFeedbacks.Remove(customer);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}