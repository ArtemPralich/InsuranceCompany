//using InsuranceCompany.Infrastructure;
using InsuranceCompany.Core;
using InsuranceCompany.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

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

        [HttpPost(Name = "CreateClient")]
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
        
            return NoContent();
        }

        [HttpDelete(Name = "DeleteClient")]
        public IActionResult Delete(Guid clientId)
        {

            return NoContent();
        }
    }
}