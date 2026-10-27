using Microsoft.EntityFrameworkCore;
using Resume.Application.Security;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Models;
using Resume.Application.Context;

namespace Resume.Application.Services.Implementations;

public class UserService : IUserService
{
    private readonly IAppDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public UserService(IAppDbContext context, IPasswordHasher passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<User> AuthenticateUserAsync(string usernameOrEmail, string password)
    {
        if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrWhiteSpace(password))
            return null;

        var normalizedInput = usernameOrEmail.Trim().ToLower();

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.IsActive && 
                (u.Username.ToLower() == normalizedInput || u.Email.ToLower() == normalizedInput));

        if (user == null)
            return null;

        bool isPasswordValid = _passwordHasher.VerifyPassword(password, user.PasswordHash);
        if (!isPasswordValid)
            return null;

        return user;
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsActive);
    }

    public async Task EnsureAdminUserExistsAsync(string defaultUsername, string defaultEmail, string defaultPassword)
    {
        bool hasAnyUser = await _context.Users.AnyAsync();
        if (!hasAnyUser)
        {
            var adminUser = new User
            {
                Username = defaultUsername,
                Email = defaultEmail,
                FullName = "Administrator",
                Role = "Admin",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                PasswordHash = _passwordHasher.HashPassword(defaultPassword)
            };

            await _context.Users.AddAsync(adminUser);
            await _context.SaveChangesAsync();
        }
    }
}
