using Microsoft.EntityFrameworkCore;
using Resume.Application.Security;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Domain.ViewModels.Message;
using Resume.Infra.Data.Context;

namespace Resume.Application.Services.Implementations;

public class MessageService : IMessageService
{
    #region Message Constructor

    private readonly AppDbContext _appDbContext;

    public MessageService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #endregion

    public async Task<Message> GetMessageByIdAsync(long id)
    {
        return await _appDbContext.Messages.SingleOrDefaultAsync(m => m.Id == id);
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
            
            await _appDbContext.AddRangeAsync(model);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<MessageViewModel>> GetMessageDataAsync()
    {
        List<MessageViewModel> result = await _appDbContext.Messages
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

        _appDbContext.Messages.Remove(result);
        await _appDbContext.SaveChangesAsync();
        return true;
    }
}