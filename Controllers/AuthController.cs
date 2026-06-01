using CollegeManagement.Models.ViewModels;
using CollegeManagement.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//View communicate with Controller using routing [Backend Routes]

//Controller -> auth/login ; auth/logout ; auth/test [ASP .NET]
//ViewModel [LoginViewModel]
//Service(AuthSerivce) [Bussiness Logic] [Interface]
//Repository(UserRepository) [AppDbContext, DB manipulation] [Interface]
//ApplicationDbContext[EF]
//Domain Model [abstraction/polymorphism/inheritance/encapsulation]
//DB Seeder
//Database(MYSQL)
namespace CollegeManagement.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Redirect("/login?error=validation");
                }

                var result = await _authService.LoginAsync(model);

                if (!result)
                {
                    return Redirect("/login?error=invalid_credentials");
                }

                return Redirect("/");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Login Error");
                Console.WriteLine(ex.Message);

                return Redirect("/login?error=server_error");
            }
        }

        [AllowAnonymous]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Content("AuthController loaded");
        }

        [Authorize]
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authService.LogoutAsync();

                return Redirect("/login");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logout Error");
                Console.WriteLine(ex.Message);

                return Redirect("/");
            }
        }
    }
}