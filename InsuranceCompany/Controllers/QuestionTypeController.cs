using InsuranceCompany.Core;
using InsuranceCompany.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IRepositoryManager _repositoryManager;
        public QuestionTypeController(ILogger<ClientController> logger, IRepositoryManager repositoryManager)
        {
            _logger = logger;
            _repositoryManager = repositoryManager;
        }

        [HttpGet(Name = "GetQuestionType")]
        public IActionResult Get()
        {
            var clients = _repositoryManager.QuestionType.GetAll(false).ToList();
            return Ok(clients);
        }

        [HttpPost(Name = "CreateQuestionType")]
        public IActionResult Create(QuestionType questionType)
        {
            _repositoryManager.QuestionType.Create(questionType);
            _repositoryManager.Save();

            return NoContent();
        }

        [HttpPut(Name = "UpdateQuestionType")]
        public IActionResult Update(QuestionType questionType)
        {
            _repositoryManager.QuestionType.Update(questionType);
            _repositoryManager.Save();
            return NoContent();
        }

        [HttpDelete(Name = "DeleteQuestionType")]
        public IActionResult Delete(Guid questionTypeId)
        {
            var questionType = _repositoryManager.QuestionType.GetById(questionTypeId, true);

            if (questionType == null)
            {
                return BadRequest();
            }

            _repositoryManager.QuestionType.Delete(questionType);
            _repositoryManager.Save();
            return NoContent();
        }
    }
}
