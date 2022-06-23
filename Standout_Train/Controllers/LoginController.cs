using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Standout_Train.ViewModels;
using System.Security.Claims;

namespace Standout_Train.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost(Name = "Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return Ok();
                }

                return BadRequest("Invalid login Attempt");
            }
            return BadRequest("Invalid login attempt");
        }

        [HttpGet]
        public async Task<IActionResult> GetConnectedUser()
        {
            try
            {
                string? userEmail = User.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrEmpty(userEmail))
                {
                    return NotFound();
                }
                return Json(userEmail);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
