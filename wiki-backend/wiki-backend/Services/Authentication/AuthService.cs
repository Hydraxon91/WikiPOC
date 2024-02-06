using Microsoft.AspNetCore.Identity;
using wiki_backend.DatabaseServices;

namespace wiki_backend.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly ITokenServices _tokenService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly WikiDbContext _dbContext;
    
    public AuthService(UserManager<IdentityUser> userManager, ITokenServices tokenService, WikiDbContext dbContext)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _dbContext = dbContext;
    }
    
    public async Task<AuthResult> RegisterAsync(string email, string username, string password, string role)
    {
        var user = new IdentityUser() { UserName = username, Email = email };
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
            return FailedRegistration(result, email, username);
        
        await _userManager.AddToRoleAsync(user, role);
        return new AuthResult(true, email, username, "");
    }

    public async Task<AuthResult> LoginAsync(string usernameOrEmail, string password)
    {
        var isEmail = IsEmail(usernameOrEmail);
        
        IdentityUser managedUser = isEmail
            ? await _userManager.FindByEmailAsync(usernameOrEmail)
            : await _userManager.FindByNameAsync(usernameOrEmail);
        if (managedUser == null)
            return isEmail ? InvalidEmail(usernameOrEmail) : InvalidUserName(usernameOrEmail);
        
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);

        if (!isPasswordValid)
            return InvalidPassword(managedUser.Email, managedUser.UserName);
        
        var roles = await _userManager.GetRolesAsync(managedUser);
        var accessToken = _tokenService.CreateToken(managedUser, roles[0]);
        
        return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
    }
    
    private static bool IsEmail(string input)
    {
        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(input);
            return mailAddress.Address == input;
        }
        catch
        {
            return false;
        }
    }
    private static AuthResult FailedRegistration(IdentityResult result, string email, string username)
    {
        var authResult = new AuthResult(false, email, username, "");

        foreach (var error in result.Errors) authResult.ErrorMessages.Add(error.Code, error.Description);

        return authResult;
    }


    private static AuthResult InvalidEmail(string email)
    {
        var result = new AuthResult(false, email, "", "");
        result.ErrorMessages.Add("Bad credentials", "Invalid email");
        return result;
    }
    
    private static AuthResult InvalidUserName(string username)
    {
        var result = new AuthResult(false, "", username, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid Username");
        return result;
    }

    private static AuthResult InvalidPassword(string email, string userName)
    {
        var result = new AuthResult(false, email, userName, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid password");
        return result;
    }
}

