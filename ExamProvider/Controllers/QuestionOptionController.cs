using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionOptionController : ControllerBase
    {
        private readonly IQuestionOptionService _examOptionsService;

        public QuestionOptionController(IQuestionOptionService examOptionsService)
        {
           _examOptionsService = examOptionsService;
        }

        [HttpPost]
        public async Task CreateOption(CreateQuestionOptionDTO option)
        {
            await _examOptionsService.CreateOption(option);
        }
        [HttpDelete("{id}")]
        public async Task DeleteOption(decimal id)
        {
            await _examOptionsService.DeleteOption(id);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<QuestionOptionDTO> GetOptionById(decimal id)
        {
            return await _examOptionsService.GetOptionById(id);
        }
        [HttpGet]
        public async Task<List<QuestionOptionDTO>> GetAllOptions()
        {
            return await _examOptionsService.GetAllOptions();
        }
        [HttpPut]
        public async Task UpdateOption(UpdateQuestionOptionDTO option)
        {
            await _examOptionsService.UpdateOption(option);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllOptionsByQuestionId(decimal id)
        {
            try
            {
                var options = await _examOptionsService.GetAllOptionsByQuestionId(id);
                return Ok(new ApiResponse<List<QuestionOptionDTO>>(options));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
