namespace RecipePlanner.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;

    public AuthService(DataContext context)
    {
        _context = context;
    }


    public Task<ServiceResponse<string>> Login(string email, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<Guid>> Register(User user, string password)
    {
        if (UserExists(user.Email).Result)
        {
            return new ServiceResponse<Guid>
            {
                Success = false,
                Message = "User already exists"
            };
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new ServiceResponse<Guid>
        {
            Data = user.Id,
            Message = "User registered successfully"
        };
    }

    public async Task<bool> UserExists(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower()));
    }
}
