using InsuranceCompany.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceRequestController : ControllerBase
    {
        private readonly ILogger<InsuranceRequestController> _logger;
        private readonly IRepositoryManager _repositoryManager;
        public InsuranceRequestController(ILogger<InsuranceRequestController> logger, IRepositoryManager repositoryManager)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
        }
        
        [HttpGet(Name = "GetInsuranceRequest")]
        public IActionResult Get()
        {
            var clients = _repositoryManager.Client.GetAll(false).ToList();
            return Ok(clients);
        }
    }
}
