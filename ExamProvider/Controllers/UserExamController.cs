using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net;
using ExamProvider.infra.Service;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserExamController : ControllerBase
    {
        private readonly IUserExamService _examUserService;
        private readonly IExamService _examService;
        private readonly IApiInfoService _apiInfoService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICompanyInfoService _companyInfoservise;
        public UserExamController(IUserExamService examUserService, 
            IExamService examService, 
            IApiInfoService apiInfoService,
            IHttpClientFactory httpClientFactory,
            ICompanyInfoService companyInfoService)
        {
            _examUserService = examUserService;
            _examService = examService;
            _apiInfoService = apiInfoService;
            _httpClientFactory=httpClientFactory;
            _companyInfoservise = companyInfoService;
        }

        [HttpPost]
        public async Task CreateUserExam( CreateUserExamDTO userExam)
        {
           
           await _examUserService.CreateExamUser(userExam);
          
            

        }

        
        [HttpDelete("{id}")]
        public async Task DeleteUserExam(decimal id)
        {
                await _examUserService.DeleteExamUser(id);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllUsersExams()
        {
            try
            {
                var examUsers = await _examUserService.GetAllExamsUser();
                return Ok(examUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllExamsReservations()
        {
            try
            {
                var examUsers = await _examUserService.GetAllExamsReservations();
                return Ok(new ApiResponse<List<ExamReservationDTO>>(examUsers));
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllExamsReservationsByStudentId(decimal  id)
        {
            try
            {
                var examUsers = await _examUserService.GetAllExamsReservationsByStudentId(id);
                return Ok(new ApiResponse<List<ExamReservationByStudentDTO>>(examUsers));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserExamById(decimal id)
        {
            
                var examUser = await _examUserService.GetExamUserById(id);
                return Ok(examUser);
            
            
        }

       
        [HttpPut]
        public async Task UpdateUserExam(UpdateUserExamDTO userExam)
        {
                await _examUserService.UpdateExamUser(userExam);
        }







        [HttpGet]

        public async Task<IActionResult> GetAllExamReservationsDetailsByStudentEmail(string studentEmail)
        {
            var apiKey = await _apiInfoService.GetKeyByServiceName();
            if (apiKey == null)
            {
                throw new InvalidOperationException("API key not found.");
            }
            var companyNmae = (await _companyInfoservise.GetCompanyInfoById(6)).OrganizationName;
            var decodedStudentEmail = WebUtility.UrlEncode(studentEmail);
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:1111/api/ExamReservation/GetAllExamReservationsDetailsByStudentEmail/{apiKey}?companyName={companyNmae}&studentEmail={decodedStudentEmail}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return Content(responseBody, "application/json");
        }

        [HttpGet]

        public async Task<IActionResult> GetAllExamReservationsDetails()
        {
            var apiKey = await _apiInfoService.GetKeyByServiceName();
            if (apiKey == null)
            {
                throw new InvalidOperationException("API key not found.");
            }
            var companyNmae = (await _companyInfoservise.GetCompanyInfoById(6)).OrganizationName;
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:1111/api/ExamReservation/GetAllExamReservationsDetails/{apiKey}?companyName={companyNmae}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            return Content(responseBody, "application/json");
        }



    }
}
