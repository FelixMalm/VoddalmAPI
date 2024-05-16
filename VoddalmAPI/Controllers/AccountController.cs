using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VoddalmAPI.Data.Interfaces;
using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController/*(IUserAccount userAccount)*/ : ControllerBase
    {
        private readonly UserManager<Broker> userManager;

        public AccountController(UserManager<Broker> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                Broker user = new Broker()
                {
                    UserName = userDTO.Email,
                    Email = userDTO.Email,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                };
                var result = await userManager.CreateAsync(user, userDTO.Password);

                if (result.Succeeded == false)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }

                await userManager.AddToRoleAsync(user, ApiRoles.User);
                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Someting Went Wrong {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(loginDTO.Email);
                var passwordValid = await userManager.CheckPasswordAsync(user, loginDTO.Password);

                if (user == null || passwordValid == false)
                {
                    return NotFound();
                }

                return Accepted();
            }
            catch (Exception ex)
            {
                return Problem($"Someting Went Wrong Login of {nameof(Login)}", statusCode: 500);
            }
        }
    }
}