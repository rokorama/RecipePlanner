using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace RecipePlanner.Server.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IConfiguration _config;
    private IHttpContextAccessor _httpAccessor;

    public AuthService(DataContext context, IConfiguration config, IHttpContextAccessor httpAccessor)
    {
        _context = context;
        _config = config;
        _httpAccessor = httpAccessor;
    }


    public async Task<ServiceResponse<string>> Login(string email, string password)
    {
        var response = new ServiceResponse<string>();
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));

        if (user == null)
        {
            response.Success = false;
            response.Message = "User not found";
        }
        else if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            response.Success = false;
            response.Message = "Incorrect password";
        }
        else
        {
            response.Data = CreateToken(user);
        }

        return response;
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

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;

    }

    public async Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Message = "User not found"
            };
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool>
        {
            Data = true,
            Message = "Password has been changed."
        };
    }

    public int GetUserId() => int.Parse(_httpAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
    public string GetUserEmail() => _httpAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;
}
