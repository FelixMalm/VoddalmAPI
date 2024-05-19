using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VoddalmAPI.Data.Interfaces;
using VoddalmAPI.Data.Models;

namespace VoddalmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController/*(IUserAccount userAccount)*/ : ControllerBase
    {
        private readonly UserManager<Broker> userManager;
        private readonly IAgency AgencyRepository;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<Broker> userManager, IAgency agencyRepository, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.AgencyRepository = agencyRepository;
            this.configuration = configuration;
        }




        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDTO, IAgency agencyRepository)
        {
            try
            {
                var passwordHasher = new PasswordHasher<Broker>();
                Broker user = new Broker()
                {
                    UserName = userDTO.Email,
                    Email = userDTO.Email,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    PhoneNumber = userDTO.PhoneNumber,
                    EmailConfirmed = true,
                    NormalizedUserName = userDTO.Email.ToUpper(),
                    NormalizedEmail = userDTO.Email.ToUpper(),
                };
                if (userDTO.AgencyId.HasValue)
                {
                    var agency = await agencyRepository.GetAgencyWithIdAsync(userDTO.AgencyId.Value);
                    if (agency == null)
                    {
                        return BadRequest();
                    }
                    user.Agency = agency;
                }

                user.PasswordHash = passwordHasher.HashPassword(user, userDTO.Password);
                var result = await userManager.CreateAsync(user);

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
                return Problem($"Something Went Wrong {nameof(Register)}", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginDTO loginDTO)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(loginDTO.Email);
                var passwordValid = await userManager.CheckPasswordAsync(user, loginDTO.Password);

                if (user == null || passwordValid == false)
                {
                    return NotFound();
                }

                string tokenstring = await GenerateToken(user);

                var response = new AuthResponse
                {
                    Email = loginDTO.Email,
                    Token = tokenstring,
                    UserId = user.Id,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem($"Someting Went Wrong Login of {nameof(Login)}", statusCode: 500);
            }
        }
        private async Task<string> GenerateToken(Broker user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();
            var userClaims = await userManager.GetClaimsAsync(user);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }
            .Union(roleClaims)
            .Union(userClaims);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}