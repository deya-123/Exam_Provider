using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using ExamProvider.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
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
        [HttpGet]
        [Route("{id}")]
        public async Task<UserInfoDTO> GetUserInfoById(decimal id)
        {
            return await _userInfoService.GetUserInfoById(id);
        }
        [HttpGet]
        public async Task<ApiResponse<List<StudentDTO>>> GetStudents()
        {
            return  new ApiResponse<List<StudentDTO>>(await _userInfoService.GetStudents());
        }
    }
}
