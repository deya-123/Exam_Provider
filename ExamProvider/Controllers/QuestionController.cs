using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _examQuestionService;

        public QuestionController(IQuestionService service)
        {
            _examQuestionService = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion(CreateQuestionDTO question)
        {
            try
            {
                await _examQuestionService.CreateQuestion(question);
                return Ok("Question created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

       
        [HttpDelete("{id}")]
        public async Task DeleteQuestion(decimal id)
        {
                await _examQuestionService.DeleteQuestion(id);
         
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(decimal id)
        {
            try
            {
                var question = await _examQuestionService.GetQuestionById(id);
                return Ok(question);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

  
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var questions = await _examQuestionService.GetAllQuestions();
                return Ok(questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task UpdateQuestion(UpdateQuestionDTO question)
        {
                await _examQuestionService.UpdateQuestion(question);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllQuestionsByExamId(decimal id)
        {
            try
            {
                var questions = await _examQuestionService.GetAllQuestionsByExamId(id);
                return Ok(new ApiResponse<List<QuestionDTO>>(questions));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
    }
