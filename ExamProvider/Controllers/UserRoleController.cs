using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpPost]
        public async Task CreateUserRole(CreateUserRoleDTO userRole)
        {
            await _userRoleService.CreateUserRole(userRole);
        }
        [HttpPut]
        public async Task UpdateUserRole(UpdateUserRoleDTO userRole)
        {
            await _userRoleService.UpdateUserRole(userRole);
        }
        [HttpDelete("{id}")]
        public async Task DeleteUserRole(int id)
        {
            await _userRoleService.DeleteUserRole(id);
        }
        [HttpGet]
        public async Task<List<UserRoleDTO>> GetUserRoles()
        {
            return await _userRoleService.GetUserRoles();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<UserRoleDTO> GetUserRoleById(decimal id)
        {
            return await _userRoleService.GetUserRoleById(id);
        }

    }
}
