using Resume.Domain.Models;
using Resume.Application.ViewModels.CustomerFeedback;

namespace Resume.Application.Services.Interfaces;

public interface ICustomerFeedBackService
{
    Task<CustomerFeedback> GetCustomerFeedBackByIdAsync(long id);
    Task<List<CustomerFeedBackViewModel>> GetCustomerFeedBackForIndexAsync();
    Task<UpsertCustomerFeedbackViewModel> FillUpsertCustomerFeedbackAsync(long id);
    Task<bool> UpsertCustomerFeedbackAsync(UpsertCustomerFeedbackViewModel customerFeedback);
    Task<bool> DeleteCustomerFeedbackAsync(long id);
}