using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserExamController : ControllerBase
    {
        private readonly IUserExamService _examUserService;

        public UserExamController(IUserExamService examUserService)
        {
            _examUserService = examUserService;
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
    }
}
