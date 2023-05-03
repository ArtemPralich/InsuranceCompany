using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using InsuranceCompany.Shared.ModelDto.Create;
using InsuranceCompany.Shared.ModelDto.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            foreach(var ins in insuranceRequestsDto.InsuranceRate.InsuranceTypeSurveys)
            {
                foreach(var question in ins.InsuranceSurvey.Questions)
                {
                    question.AnswerValues = question.AnswerValues.Where(q => q.InsuranceRequestId == insuranceRequest.Id).ToList();
                }
            }

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

            var insRate = _repositoryManager.InsuranceRate.GetById(insuranceRequestDto.InsuranceRateId ?? Guid.NewGuid(), false);
            var rates = insRate.InsuranceTypeSurveys.ToList();
            foreach(var rate in rates)
            {
                foreach (var questionSurvey in rate.InsuranceSurvey.QuestionSurveys)
                {
                    insuranceRequest.AnswerValues.Add(new AnswerValue()
                    {
                        QuestionId = questionSurvey.Question.Id,
                        InsuranceRequest = insuranceRequest,
                        InsuranceSurveyId = rate.InsuranceSurvey.Id,
                        Value = ""
                    });
                }
            }
            _repositoryManager.InsuranceRequest.Create(insuranceRequest);
            _repositoryManager.Save();

            return Ok(insuranceRequest.Id);
        }

        [HttpPut(Name = "UpdateInsuranceRequest")]
        public IActionResult Update(UpdateInsuranceDto insuranceRequestDto)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true // optional for pretty-printing the JSON
            };

            var insuranceRequest = _repositoryManager.InsuranceRequest.GetByIdForCreate(insuranceRequestDto.Id, true);
            var json = JsonSerializer.Serialize(insuranceRequest, options);

            if (insuranceRequest == null)
            {
                return NotFound();
            }
            
            _mapper.Map(insuranceRequestDto, insuranceRequest);

            var json1 = JsonSerializer.Serialize(insuranceRequest, options);
            _repositoryManager.InsuranceRequest.Update(insuranceRequest);
            _repositoryManager.Save();

            var insuredPersonForCreate = insuranceRequestDto.InsuredPersons.Where(p => Guid.Empty.Equals(p.Id) || p.Id == null).ToList();
            foreach(var person in insuredPersonForCreate)
            {
                if(person.Client.PersonalCode == null)
                {
                    person.Client.PersonalCode = "";
                }
            }
            var insuredPersonForDelete = insuranceRequest.InsuredPersons.Where(p => !insuranceRequestDto.InsuredPersons.Select(pr => pr.Id).Contains(p.Id)).ToList();
            var insuredPersonForUpdate = _repositoryManager.InsuredPerson.GetRangeByIds(insuranceRequest.InsuredPersons.Select(x => x.Id).ToList(), true);

            foreach(var insuredPerson in insuredPersonForUpdate)
            {
                _mapper.Map(insuranceRequestDto.InsuredPersons.Where(i => i.Id.Equals(insuredPerson.Id)).FirstOrDefault(), insuredPerson);
            }

            var newPersons = _mapper.Map<List<InsuredPerson>>(insuredPersonForCreate);
            _repositoryManager.InsuredPerson.UpdateRange(insuredPersonForUpdate);
            _repositoryManager.InsuredPerson.CreateRange(newPersons);
            _repositoryManager.InsuredPerson.DeleteRange(insuredPersonForDelete);

            
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
 