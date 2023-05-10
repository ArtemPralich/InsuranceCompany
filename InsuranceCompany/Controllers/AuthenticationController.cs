using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InsuranceCompany.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        private readonly IRepositoryManager _repositoryManager;
        public AuthenticationController(UserManager<User> userManager, IAuthenticationManager authManager, IRepositoryManager repositoryManager)
        {
            _userManager = userManager;
            _authManager = authManager;
            _repositoryManager = repositoryManager;
        }
        [HttpPost]
        [Route("RegisterClient")]
        public async Task<IActionResult> RegisterClient([FromBody] RegistrationClientDto userForRegistration)
        {
            //var user = _mapper.Map<User>(userForRegistration); 
            var client = new Client()
            {
                PersonalCode = ""
            };
            _repositoryManager.Client.Create(client);
            var user = new User()
            {
                FirstName = "",
                LastName = "",
                Email = userForRegistration.Email,
                UserName = userForRegistration.UserName,
                ClientId = client.Id
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
            if (!await _authManager.ValidateUser(new UserForAuthenticationDto() { Password = userForRegistration.Password, UserName = userForRegistration.Email }))
            {
                return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });
        }
        [HttpPost]
        [Route("RegisterAgent")]
        public async Task<IActionResult> RegisterAgent([FromBody] UserForRegistrationDto userForRegistration)
        {
            var agent = new Agent()
            {
            };
            _repositoryManager.Agent.Create(agent);
            //var user = _mapper.Map<User>(userForRegistration); 
            var user = new User()
            {
                FirstName = userForRegistration.FirstName,
                LastName = userForRegistration.LastName,
                Email = userForRegistration.Email,
                UserName = userForRegistration.UserName,
                AgentId = agent.Id
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

            await _userManager.AddToRolesAsync(user, new List<string>() { "Agent" });
            ICollection<string> roles = await _authManager.GetRoles(user.UserName);
            if (roles != null)
            {
                Response.Headers.Add("Roles", JsonConvert.SerializeObject(roles));
            }

            if (!await _authManager.ValidateUser(new UserForAuthenticationDto() { Password = userForRegistration.Password, UserName = userForRegistration.UserName}))
            {
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken(), Role = roles.FirstOrDefault() });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }

            ICollection<string> roles = await _authManager.GetRoles(user.UserName);
            if (roles != null)
            {
                Response.Headers.Clear();
                Response.Headers.Add("Roles", JsonConvert.SerializeObject(roles));
            }

            return Ok(new { Token = await _authManager.CreateToken(), Role = roles.FirstOrDefault() });
        }

    }
}
