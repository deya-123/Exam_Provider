﻿using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using ExamProvider.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IApiInfoService _apiInfoService;
        public ExamController(IExamService examService, IApiInfoService apiInfoService)
        {
            _examService = examService;
            _apiInfoService = apiInfoService;
        }

        [HttpPost]

        public async Task<IActionResult> CreateExam(CreateExamDTO exam)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Keys.Where(key => ModelState[key].Errors.Any())
                    .ToDictionary(key => key, key => ModelState[key].Errors.Select(x => x.ErrorMessage).ToList());
                var response = new ApiResponse<string>(message: "Validation failed", validationErrors: validationErrors);
                return BadRequest(response);
            }
            await _examService.CreateExam(exam);
            return Ok(new ApiResponse<string>(data:"effected 1 row",message: "added exam successfully"));
         
        }

        [HttpPut]
        public async Task UpdateExam(UpdateExamDTO exam)
        {
            await _examService.UpdateExam(exam);
        }
        [HttpDelete("{id}")]
        public async Task DeleteExam(decimal id)
        {
            await _examService.DeleteExam(id);
        }
        [HttpGet]
        public async Task <ApiResponse<List<ExamDTO>>> GetAllExams()
        {
            return new ApiResponse<List<ExamDTO>>(await _examService.GetAllExams());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ExamDTO> GetExamById(decimal id)
        {
            return await _examService.GetExamById(id);
        }

        [HttpGet]
        [Route("{key}")]
        public async Task<ApiResponse<ExamDTO>> GetExamByName(string key, string examName)
        {
            var apiKey = await _apiInfoService.GetKeyByServiceName();
            if (apiKey == null)
            {
                throw new InvalidOperationException("API key not found.");
            }

            if (key != apiKey)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            return new ApiResponse<ExamDTO>(await _examService.GetExamByName(examName));
        }

        [HttpGet("{key}")]
 
        public async Task<ApiResponse<List<Exam>>> GetExamDetailsByName(string key,string examName)
        {
            var apiKey = await _apiInfoService.GetKeyByServiceName();
            if (apiKey == null)
            {
                throw new InvalidOperationException("API key not found.");
            }

            if (key != apiKey)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            return new ApiResponse<List<Exam>>( await _examService.GetExamsByName(examName));
        }

        [HttpGet("{key}")]
        public async Task<ApiResponse<List<ExamDetailsWithoutAnwersDTO>>> GetExamDetailsWithoutAnwersByName(string key, string examName)
        {
            var apiKey = await _apiInfoService.GetKeyByServiceName();
            if (apiKey == null)
            {
                throw new InvalidOperationException("API key not found.");
            }

            if (key != apiKey)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }

            return new ApiResponse<List<ExamDetailsWithoutAnwersDTO>>(await _examService.GetExamDetailsWithoutAnwersByName(examName));
        }
        
        [HttpGet]
        public async Task<ApiResponse<List<ExamDTO>>> SearchBetweenInterval(DateTime? startDate, DateTime? endDate)
        {
            return new ApiResponse<List<ExamDTO>>(await _examService.SearchBetweenInterval(startDate, endDate));
        }

        [HttpGet]
        public async Task<List<ExamDTO>> SearchSpecificDate(DateTime specificDate)
        {
            return await _examService.SearchSpecificDate(specificDate);
        }
    }
}
