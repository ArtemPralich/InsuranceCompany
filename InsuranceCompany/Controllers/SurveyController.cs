using AutoMapper;
using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using InsuranceCompany.Infrastructure;
using InsuranceCompany.Shared.ModelDto;
using InsuranceCompany.Shared.ModelDto.Create;
using InsuranceCompany.Shared.ModelDto.Update;
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
            var insuranceRequestsDto = _mapper.Map<List<InsuranceSurveyDto>>(insuranceRequests);
            return Ok(insuranceRequestsDto);
        }

        [HttpPost("CreateQuestion", Name = "CreateQuestion")]
        public IActionResult CreateQuestion([FromBody] CreateQuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);

            var questionSurvey = new QuestionSurvey() { InsuranceSurveyId = questionDto.SyrveyId, Question = question };
            _repositoryManager.QuestionSurvey.Create(questionSurvey);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpPost(Name = "CreateSurvey")]
        public IActionResult CreateSurvey(CreateSurveyDto surveyDto)
        {
            var survey = _mapper.Map<InsuranceSurvey>(surveyDto);
            _repositoryManager.InsuranceSurvey.Create(survey);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpPut(Name = "UpdateInsuranceSurvey")]
        public IActionResult Update(UpdateInsuranceSurveyDto insuranceSurveyDto)
        {
            var survey = _repositoryManager.InsuranceSurvey.GetByForUpdateId(insuranceSurveyDto.Id, true);

            List<QuestionSurvey> questions = survey.QuestionSurveys.ToList();
            List<Answer> answers = new List<Answer>();
            questions.ForEach(q => answers.AddRange(q.Question.Answers));
            var questionForCreatingDto = insuranceSurveyDto.Questions.Where(q => Guid.Empty ==  q.Id).ToList();
            var questionForCreating =  _mapper.Map<List<Question>>(questionForCreatingDto);
            
            List<QuestionSurvey> questionForDeleting = new List<QuestionSurvey>();
            var questionIds = insuranceSurveyDto.Questions.Select(x => x.Id).ToList();
            foreach(QuestionSurvey question in questions)
            {
                if (!questionIds.Contains(question.QuestionId ?? Guid.Empty))
                {
                    questionForDeleting.Add(question);
                }
            }
            _mapper.Map(insuranceSurveyDto, survey);

            List<AnswerDto> answersForCreatingDto = new List<AnswerDto>();
            //List<Answer> answersForCreating = new List<Answer>();
            foreach (var question in insuranceSurveyDto.Questions)
            {
                var newAnswers = question.Answers.Where(a => a.Id == Guid.Empty);
                foreach(var answer in newAnswers)
                {
                    answer.QuestionId = question.Id;
                }
                answersForCreatingDto.AddRange(newAnswers);
            }

            List<Answer> answerForDeleting = new List<Answer>();
            List<Guid> answerIds = new List<Guid>();
            foreach(var question in insuranceSurveyDto.Questions)
            {
                answerIds.AddRange(question.Answers.Select(a => a.Id).ToList());
            }
            foreach (Answer answer in answers)
            {
                if (!answerIds.Contains(answer.Id))
                {
                    answerForDeleting.Add(answer);
                }
            }

            List<InsuranceTypeSurvey> insuranceRateTemplatesForAdd = new List<InsuranceTypeSurvey>();
            List<InsuranceTypeSurvey> insuranceRateTemplatesForDelete = new List<InsuranceTypeSurvey>();
            foreach (var rate in insuranceSurveyDto.InsuranceRates)
            {
                if (survey.InsuranceTypeSurveys.FirstOrDefault(t => t.InsuranceRateId == rate.Id) == null)
                {
                    insuranceRateTemplatesForAdd.Add(new InsuranceTypeSurvey() { InsuranceSurveyId = survey.Id, InsuranceRateId = rate.Id });
                }
            }

            insuranceRateTemplatesForDelete = survey.InsuranceTypeSurveys.Where(t => !insuranceSurveyDto.InsuranceRates.Select(x=>x.Id).ToList().Contains(t.InsuranceRateId  ?? Guid.Empty)).ToList();


            var answersForCreating = _mapper.Map<List<Answer>>(answersForCreatingDto);

            List<QuestionSurvey> questionSurvey = new List<QuestionSurvey>();
            foreach(Question question in questionForCreating)
            {
                questionSurvey.Add(new QuestionSurvey() { Question = question, InsuranceSurveyId = survey.Id });
            }
            _repositoryManager.QuestionSurvey.DeleteRange(questionForDeleting);
            _repositoryManager.QuestionSurvey.CreateRange(questionSurvey);
            _repositoryManager.InsuranceSurvey.Update(survey);
            _repositoryManager.Answer.CreateRange(answersForCreating);
            _repositoryManager.Answer.DeleteRange(answerForDeleting);
            _repositoryManager.InsuranceTypeSurvey.DeleteRange(insuranceRateTemplatesForDelete);
            _repositoryManager.InsuranceTypeSurvey.CreateRange(insuranceRateTemplatesForAdd);
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
