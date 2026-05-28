using BCrypt.Net;
using CollegeManagement.Data.Repos;
using CollegeManagement.Models.ViewModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;



namespace CollegeManagement.Sevices
{

    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
    }

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(
            IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(model.Email);

                if (user == null)
                    return false;

                var isPasswordValid = BCrypt.Net.BCrypt.Verify(
                    model.Password,
                    user.PasswordHash
                );

                if (!isPasswordValid)
                    return false;

                var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role)
        };

                var identity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                );

                var principal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe,
                    ExpiresUtc = model.RememberMe
                        ? DateTimeOffset.UtcNow.AddDays(7)
                        : null
                };

                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext == null)
                    return false;

                await httpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    authProperties
                );

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during login.");
                Console.WriteLine(ex.Message);

                // Optional:
                // Console.WriteLine(ex.StackTrace);

                return false;
            }
        }
        public async Task LogoutAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                await httpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme
                );
            }
        }
    }
}
