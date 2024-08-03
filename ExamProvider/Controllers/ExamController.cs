using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using ExamProvider.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IApiInfoService _apiInfoService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICompanyInfoService _companyInfoservise;
        public ExamController(IExamService examService, IApiInfoService apiInfoService, 
            IHttpClientFactory httpClientFactory, ICompanyInfoService companyInfoservise)
        {
            _examService = examService;
            _apiInfoService = apiInfoService;
            _httpClientFactory = httpClientFactory;
            _companyInfoservise=
            _companyInfoservise = companyInfoservise;
        }

        [HttpPost]

        public async Task<IActionResult> CreateExam([FromBody]CreateExamDTO exam, [FromQuery] bool isAdded)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Keys.Where(key => ModelState[key].Errors.Any())
                    .ToDictionary(key => key, key => ModelState[key].Errors.Select(x => x.ErrorMessage).ToList());
                var responseErrors = new ApiResponse<string>(message: "Validation failed", validationErrors: validationErrors);
                return BadRequest(responseErrors);
            }


            if (isAdded) {
                var apiKey = await _apiInfoService.GetKeyByServiceName();
                if (apiKey == null)
                {
                    throw new InvalidOperationException("API key not found.");
                }

                var client = _httpClientFactory.CreateClient();
                var companyNmae = (await _companyInfoservise.GetCompanyInfoById(6)).OrganizationName;

                var url = $"https://localhost:1111/api/ExamInfo/AddExamByName/{apiKey}?companyName={companyNmae}";
                var response = await client.PostAsJsonAsync(url, new
                {
                    ExamTitle = exam.ExamName,
                    Price = exam.Price
                });

                response.EnsureSuccessStatusCode();
            }
           

            //var responseBody = await response.Content.ReadAsStringAsync();

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
        public async Task<ApiResponse<List<ExamDTO>>> GetAllActiveExams()
        {
            return new ApiResponse<List<ExamDTO>>(await _examService.GetAllActiveExams());
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


        [HttpGet("{key}")]
        public async Task<IActionResult> AddExam()
        {
            var apiKey = await _apiInfoService.GetKeyByServiceName();
            if (apiKey == null)
            {
                throw new InvalidOperationException("API key not found.");
            }

            var client = _httpClientFactory.CreateClient();


            var url = $"https://localhost:1111/api/ExamInfo/AddExamByName/{apiKey}?companyName=Deya";
            var response = await client.PostAsJsonAsync(url, new { 
            ExamTitle="",
            Price=20
            });

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return Content(responseBody, "application/json");
        }
        [HttpGet("{id}")]
        public async Task UpdateState(decimal id, [FromQuery] string state)
        {
            await _examService.UpdateState(id, state);
        }



    }
}
