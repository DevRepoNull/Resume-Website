using Resume.Domain.Models;

namespace Resume.Application.Services.Interfaces;

public interface IUserService
{
    Task<User> AuthenticateUserAsync(string usernameOrEmail, string password);
    Task<User> GetUserByIdAsync(long id);
    Task EnsureAdminUserExistsAsync(string defaultUsername, string defaultEmail, string defaultPassword);
}
