using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Standout_Train.BL.Interfaces;
using Standout_Train.DAL.Models;
using Standout_Train.TL.DTOs;
using Standout_Train.ViewModels;

namespace Standout_Train.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IUnitOfWork unitOfWork,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser
                    {
                        UserName = registerViewModel.Email,
                        Email = registerViewModel.Email,
                    };

                    var result = await _userManager.CreateAsync(user, registerViewModel.Password);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        CustomerDTO dto = new CustomerDTO
                        {
                            FirstName = registerViewModel.FirstName,
                            EmailAdress = registerViewModel.Email,
                            Age = registerViewModel.Age
                        };
                        await _unitOfWork.Customers.AddAsync(_mapper.Map<Customer>(dto));
                        return Ok();
                    }
                }
                return BadRequest(nameof(registerViewModel));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
