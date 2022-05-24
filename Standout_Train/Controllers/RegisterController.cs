using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Standout_Train.ViewModels;

namespace Standout_Train.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email,
                };

                var result = await _userManager.CreateAsync(user,registerViewModel.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok();
                }

                return BadRequest(result.Errors.FirstOrDefault());
            }
            return BadRequest(nameof(registerViewModel));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
