using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceStatusController : ControllerBase
    {
        private readonly ILogger<InsuranceStatusController> _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public InsuranceStatusController(ILogger<InsuranceStatusController> logger, IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetInsuranceStatus")]
        public IActionResult Get()
        {
            var insuranceRequests = _repositoryManager.InsuranceStatus.GetAll(false);
            return Ok(insuranceRequests);
        }

        [HttpPost(Name = "CreateInsuranceStatus")]
        public IActionResult Create(InsuranceStatus insuranceRequest)
        {
            insuranceRequest.Id = Guid.NewGuid();
            _repositoryManager.InsuranceStatus.Create(insuranceRequest);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpPut(Name = "UpdateInsuranceStatus")]
        public IActionResult Update(InsuranceStatus insuranceRequest)
        {
            _repositoryManager.InsuranceStatus.Update(insuranceRequest);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpDelete(Name = "DeleteInsuranceStatus")]
        public IActionResult Delete(Guid insuranceStatusId)
        {
            var insuranceStatus = _repositoryManager.InsuranceStatus.GetById(insuranceStatusId, true);

            if (insuranceStatus == null)
            {
                return BadRequest();
            }

            _repositoryManager.InsuranceStatus.Delete(insuranceStatus);
            _repositoryManager.Save();
            return NoContent();
        }
    }
}
