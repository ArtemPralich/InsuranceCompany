using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using InsuranceCompany.Shared.ModelDto.Create;
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

            return Ok(insuranceRequestsDto);
        }

        [HttpGet("{id}", Name = "GetInsuranceRequestById")]
        public IActionResult GetById(Guid id)
        {
            var insuranceRequest = _repositoryManager.InsuranceRequest.GetById(id, false);
            var insuranceRequestsDto = _mapper.Map<InsuranceRequestDto>(insuranceRequest);

            return Ok(insuranceRequestsDto);
        }

        [HttpPost(Name = "CreateInsuranceRequest")]
        public IActionResult Create(CreateInsuranceRequestDto insuranceRequestDto)
        {
            var insuranceRequest = _mapper.Map<InsuranceRequest>(insuranceRequestDto);
            var client = _mapper.Map<Client>(insuranceRequestDto.Client);
            insuranceRequest.InsuredPersons.Add(new Core.Models.InsuredPerson()
            {
                InsuranceRequest = insuranceRequest,
                Client = client,
                IsMainInsuredPerson = true
            });
            insuranceRequest.InsuranceStatus = _repositoryManager.InsuranceStatus.GetByStatus("Создано", true);
            _repositoryManager.InsuranceRequest.Create(insuranceRequest);
            _repositoryManager.Save();

            return Ok(insuranceRequest.Id);
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
