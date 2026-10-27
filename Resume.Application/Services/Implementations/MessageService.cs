using Microsoft.EntityFrameworkCore;
using Resume.Application.Security;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Application.ViewModels.Message;
using Resume.Application.Context;

namespace Resume.Application.Services.Implementations;

public class MessageService : IMessageService
{
    #region Message Constructor

    private readonly IAppDbContext _IAppDbContext;

    public MessageService(IAppDbContext IAppDbContext)
    {
        _IAppDbContext = IAppDbContext;
    }

    #endregion

    public async Task<Message> GetMessageByIdAsync(long id)
    {
        return await _IAppDbContext.Messages.SingleOrDefaultAsync(m => m.Id == id);
    }

    public async Task<bool> CreateMessageAsync(CreateMessageViewModel message)
    {
        try
        {
            Message model = new Message()
            {
                Name = message.Name.SanitizeText(),
                Email = message.Email.SanitizeText(),
                Text = message.Text.SanitizeText()
            };
            
            await _IAppDbContext.Messages.AddAsync(model);
            await _IAppDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<MessageViewModel>> GetMessageDataAsync()
    {
        List<MessageViewModel> result = await _IAppDbContext.Messages
            .Select(m => new MessageViewModel()
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                Text = m.Text
            }).ToListAsync();

        return result;
    }

    public async Task<bool> DeleteMessageAsync(long id)
    {
        if (id == 0)
            return false;

        Message result = await GetMessageByIdAsync(id);

        if (result == null)
            return false;

        _IAppDbContext.Messages.Remove(result);
        await _IAppDbContext.SaveChangesAsync();
        return true;
    }
}