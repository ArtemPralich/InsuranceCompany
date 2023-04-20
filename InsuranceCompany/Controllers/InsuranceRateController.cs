using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto.Create;
using InsuranceCompany.Shared.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceRateController : ControllerBase
    {
        private readonly ILogger<InsuranceRequestController> _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public InsuranceRateController(ILogger<InsuranceRequestController> logger, IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetInsuranceRates")]
        public IActionResult Get()
        {
            var insuranceRate = _repositoryManager.InsuranceRate.GetAll(false);

            return Ok(insuranceRate);
        }

        [HttpPost("AddSurvey", Name = "AddSurvey")]
        public IActionResult AddSurvey(AddSurveyToRateDto survey)
        {
            var insSurvey = _mapper.Map<InsuranceTypeSurvey>(survey);
            _repositoryManager.InsuranceTypeSurvey.Create(insSurvey);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpPost(Name = "CreateInsuranceRate")]
        public IActionResult Create(CreateInsuranceRateDto insuranceRateDto)
        {
            var insuranceRate = _mapper.Map<InsuranceRate>(insuranceRateDto);
            _repositoryManager.InsuranceRate.Create(insuranceRate);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpPut(Name = "UpdateInsuranceRate")]
        public IActionResult Update(InsuranceRate insuranceRate)
        {
            _repositoryManager.InsuranceRate.Update(insuranceRate);
            _repositoryManager.Save();

            return NoContent();
        }

    }
}
