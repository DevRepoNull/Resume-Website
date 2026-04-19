using Resume.Domain.Models;
using Resume.Domain.ViewModels.Message;

namespace Resume.Application.Services.Interfaces;

public interface IMessageService
{
    Task<Message> GetMessageByIdAsync(long id);

    Task<bool> CreateMessageAsync(CreateMessageViewModel message);

    Task<List<MessageViewModel>> GetMessageDataAsync();

    Task<bool> DeleteMessageAsync(long id);
}