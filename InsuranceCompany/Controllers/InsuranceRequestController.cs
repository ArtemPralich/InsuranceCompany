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
    public class InsuranceRequestController : ControllerBase
    {
        private readonly ILogger<InsuranceRequestController> _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public InsuranceRequestController(ILogger<InsuranceRequestController> logger, IRepositoryManager repositoryManager, 
            IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetInsuranceRequest")]
        public IActionResult Get()
        {
            var insuranceRequests = _repositoryManager.InsuranceRequest.GetAll(false);
            var insuranceRequestsDto = _mapper.Map<List<InsuranceRequestDto>>(insuranceRequests);
            //foreach(var i in insuranceRequestsDto)
            //{
            //    i.MainClient = i.InsuredPersons.FirstOrDefault(ip => ip.IsMainInsuredPerson)?.Client;
            //}
            return Ok(insuranceRequestsDto);
        }

        [HttpPost(Name = "CreateInsuranceRequest")]
        public IActionResult Create(InsuranceRequest insuranceRequest)
        {
            insuranceRequest.Id = Guid.NewGuid();
            _repositoryManager.InsuranceRequest.Create(insuranceRequest);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpPut(Name = "UpdateInsuranceRequest")]
        public IActionResult Update(InsuranceRequest insuranceRequest)
        {
            _repositoryManager.InsuranceRequest.Update(insuranceRequest);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpDelete(Name = "DeleteInsuranceRequest")]
        public IActionResult Delete(Guid insuranceRequestId)
        {
            var insuranceRequest = _repositoryManager.InsuranceRequest.GetById(insuranceRequestId, true);

            if (insuranceRequest == null)
            {
                return BadRequest();
            }

            _repositoryManager.InsuranceRequest.Delete(insuranceRequest);
            _repositoryManager.Save();
            return NoContent();
        }
    }
}
