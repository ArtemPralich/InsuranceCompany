using InsuranceCompany.Core.Models;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        public AuthenticationController(UserManager<User> userManager, IAuthenticationManager authManager)
        {
            _userManager = userManager;
            _authManager = authManager;
        }
        [HttpPost]
        [Route("RegisterClient")]
        public async Task<IActionResult> RegisterClient([FromBody] RegistrationClientDto userForRegistration)
        {
            //var user = _mapper.Map<User>(userForRegistration); 
            var user = new User()
            {
                FirstName = "",
                LastName = "",
                Email = userForRegistration.Email,
                UserName = userForRegistration.UserName,
            };
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, new List<string>() { "Client" } );
            return StatusCode(201);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            //var user = _mapper.Map<User>(userForRegistration); 
            var user = new User()
            {
                FirstName = userForRegistration.FirstName,
                LastName = userForRegistration.LastName,
                Email = userForRegistration.Email,
                UserName = userForRegistration.UserName,
            };
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });
        }

    }
}
