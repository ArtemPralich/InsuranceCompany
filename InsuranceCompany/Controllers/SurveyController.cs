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
    public class SurveyController : ControllerBase
    {
        private readonly ILogger<SurveyController> _logger;
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SurveyController(ILogger<SurveyController> logger, IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetInsuranceSurvey")]
        public IActionResult Get()
        {
            var insuranceRequests = _repositoryManager.InsuranceSurvey.GetAll(false);
            return Ok(insuranceRequests);
        }

        [HttpPost(Name = "CreateQuestion")]
        public IActionResult Create(CreateQuestionDto answerDto)
        {
            var answer = _mapper.Map<Question>(answerDto);
            _repositoryManager.Question.Create(answer);
            _repositoryManager.Save();

            return NoContent();
        }

        //[HttpPost(Name = "CreateQuestion")]
        //public IActionResult CreateQuestion(CreateQuestionDto questionDto)
        //{
        //    _repositoryManager.InsuranceSurvey.Create(insuranceSurvey);
        //    _repositoryManager.Save();

        //    return NoContent();
        //}

        [HttpPut(Name = "UpdateInsuranceSurvey")]
        public IActionResult Update(InsuranceSurvey insuranceSurvey)
        {
            _repositoryManager.InsuranceSurvey.Update(insuranceSurvey);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpDelete(Name = "DeleteInsuranceSurvey")]
        public IActionResult Delete(Guid insuranceStatusId)
        {
            var insuranceSurvey = _repositoryManager.InsuranceSurvey.GetById(insuranceStatusId, true);

            if (insuranceSurvey == null)
            {
                return BadRequest();
            }

            _repositoryManager.InsuranceSurvey.Delete(insuranceSurvey);
            _repositoryManager.Save();
            return NoContent();
        }
    }
}
