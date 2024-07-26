using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

  
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {

            _userRoleRepository = userRoleRepository;
        }

        public async Task CreateUserRole(CreateUserRoleDTO userRole)
        {
            await _userRoleRepository.CreateUserRole(userRole);
        }

        public async Task DeleteUserRole(decimal id)
        {
            await _userRoleRepository.DeleteUserRole(id);
        }

        public async Task<UserRoleDTO> GetUserRoleById(decimal id)
        {
           return await _userRoleRepository.GetUserRoleById(id);
        }

        public async Task<List<UserRoleDTO>> GetUserRoles()
        {
          return  await _userRoleRepository.GetUserRoles();
        }

        public async Task UpdateUserRole(UpdateUserRoleDTO userRole)
        {
            await _userRoleRepository.UpdateUserRole(userRole);
        }
    }
}
