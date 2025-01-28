using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.IdentityServer.Models;
using Shop.IdentityServer.Models.DTOs;
using System.Threading.Tasks;

namespace Shop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,

            };
            var result=await _userManager.CreateAsync(values,userRegisterDto.Password);

            if (result.Succeeded)
            {
                return Ok("User verify");
            }

            else
            {
                return Ok("User not verify");    
            }
        }
    }
}
