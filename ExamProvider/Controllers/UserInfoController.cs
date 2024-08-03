using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using ExamProvider.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        private readonly IApiInfoService _apiInfoService;
        public UserInfoController(IUserInfoService userInfoService,IApiInfoService apiInfoService)
        {
            _userInfoService = userInfoService;
            _apiInfoService = apiInfoService;
        }
        [HttpPost]
        public async Task CreateUserInfo(CreateUserInfoDTO userInfo)
        {
            await _userInfoService.CreateUserInfo(userInfo);
        }
        [HttpPut]
        public async Task UpdateUserInfo(UpdateUserInfoDTO userInfo)
        {
            await _userInfoService.UpdateUserInfo(userInfo);
        }
        [HttpDelete("{id}")]
        public async Task DeleteUserInfo(decimal id)
        {
            await (_userInfoService.DeleteUserInfo(id));
        }
        [HttpGet]
        public async Task<List<UserInfoDTO>> GetUsersInfo()
        {
            return await _userInfoService.GetUsersInfo();
        }
        [HttpGet("{id}")]
        public async Task<UserInfoDTO> GetUserInfoById(decimal id)
        {
            return await _userInfoService.GetUserInfoById(id);
        }


        [HttpGet("{key}")]
 
        public async Task<UserInfoDTO> GetUserInfoByIdAndKey(string key,decimal id)
        {
            var apiKey =await _apiInfoService.GetKeyByServiceName();
            if (apiKey == null)
            {  
                throw new InvalidOperationException("API key not found.");
            }

            if (key != apiKey)
            {
                throw new UnauthorizedAccessException("Invalid API key.");
            }


            return await _userInfoService.GetUserInfoById(id);
        }
        [HttpGet("{key}")]
        public async Task<ApiResponse<StudentDTO>> GetStudentInfoById(string key,decimal id)
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

            return new ApiResponse<StudentDTO>(await _userInfoService.GetStudentInfoById(id));
        }


        [HttpGet]
        public async Task<ApiResponse<List<StudentDTO>>> GetStudents()
        {
            return new ApiResponse<List<StudentDTO>>(await _userInfoService.GetStudents());
        }

        [HttpGet("{key}")]
        public async Task<ApiResponse<StudentDTO>> GetStudentInfoByEmail(string key,string email)
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

            return new ApiResponse<StudentDTO>(await _userInfoService.GetStudentInfoByEmail(email));
        }

  

    }
}
