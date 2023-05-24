using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        public ClientController(ILogger<ClientController> logger, IRepositoryManager repositoryManager,
            UserManager<User> userManager)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;

            _userManager = userManager;
        }

        [HttpGet(Name = "GetClient")]
        public IActionResult Get()
        {
            var clients = _repositoryManager.Client.GetAll(false).ToList();
            return Ok(clients);
        }

        [HttpGet]
        [Authorize(Roles = "Client")]
        [Route("GetClientPrivateInfo")]
        public async Task<IActionResult> GetProduct()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var client = _repositoryManager.Client.GetById(user.ClientId ?? Guid.Empty, false);
            var insuredPerson = _repositoryManager.InsuredPerson
                .FindByCondition(i => i.ClientId == user.ClientId && i.IsMainInsuredPerson, false)
                .Include(i => i.InsuranceRequest).ThenInclude(i => i.InsuranceStatus)
                .Include(i => i.InsuranceRequest).ThenInclude(i => i.InsuranceRate)
                .Include(i => i.InsuranceRequest).ThenInclude(i => i.Documents).ToList();

            //client.InsuredPersons = insuredPerson;
            var clientDto = new PrivateClientInfo()
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                PersonalCode = client.PersonalCode,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Address = client.Address,
                Gender = client.Gender,
                DateOfBirth = client.DateOfBirth,
                InsuranceRequests = insuredPerson.Select(i => i.InsuranceRequest).ToList()
            };

            return Ok(clientDto);
        }
        [HttpGet]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            string password = "";
            {
                Random random = new Random();
                bool containsNumber = false;

                while (!containsNumber || password.Length < 16)
                {
                    password = "";
                    containsNumber = false;

                    for (int i = 0; i < 16; i++)
                    {
                        char c = (char)random.Next(33, 127); // генерируем случайный символ из ASCII таблицы
                        password += c;

                        if (char.IsNumber(c))
                        {
                            containsNumber = true;
                        }
                    }
                }
            }
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, password);
                if (result.Succeeded)
                {
                    _repositoryManager.Email.SendEmailMessage(email, "Ваш пароль", "Мы генерировали для вас новый пароль: " + password);
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto passwordDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user, passwordDto.OldPassword))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, token, passwordDto.Password);
                    if (result.Succeeded)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest("Неверный пароль");
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        [Route("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var token = await _userManager.GenerateChangeEmailTokenAsync(user, email);
                var result = await _userManager.ChangeEmailAsync(user, email, token);

                if (result.Succeeded)
                {
                    user.UserName = email;
                    var result1 = await _userManager.UpdateAsync(user);
                    if (result1.Succeeded)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost(Name = "CreateClient"), Authorize]
        public IActionResult Create(Client client)
        {
            client.Id = Guid.NewGuid();
            _repositoryManager.Client.Create(client);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpPut(Name = "UpdateClient")]
        public IActionResult Update(Client client)
        {
            _repositoryManager.Client.Update(client);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpDelete(Name = "DeleteClient")]
        public IActionResult Delete(Guid clientId)
        {
            var client = _repositoryManager.Client.GetById(clientId, true);

            if(client == null)
            {
                return BadRequest();
            }

            _repositoryManager.Client.Delete(client);
            _repositoryManager.Save();
            return NoContent();
        }
    }
}