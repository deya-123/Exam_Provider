using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IUserRoleService
    {

        Task<List<UserRoleDTO>> GetUserRoles();
        Task<UserRoleDTO> GetUserRoleById(decimal id);
        Task CreateUserRole(CreateUserRoleDTO userRole);
        Task UpdateUserRole(UpdateUserRoleDTO userRole);
        Task DeleteUserRole(decimal id);
    }
}
