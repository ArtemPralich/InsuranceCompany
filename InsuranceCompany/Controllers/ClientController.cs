using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {    
        private readonly ILogger<ClientController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        public ClientController(ILogger<ClientController> logger, IRepositoryManager repositoryManager, UserManager<User> userManager)
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

            return Ok(client);
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