//using InsuranceCompany.Infrastructure;
using InsuranceCompany.Core;
using InsuranceCompany.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {    
        private readonly ILogger<ClientController> _logger;
        private readonly IRepositoryManager _repositoryManager;
        public ClientController(ILogger<ClientController> logger, IRepositoryManager repositoryManager )
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
        }

        [HttpGet(Name = "GetClient")]
        public IActionResult Get()
        {
            var clients = _repositoryManager.Client.GetAll(false).ToList();
            return Ok(clients);
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