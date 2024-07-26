using ExamProvider.core.Data;

using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IUserInfoService
    {
        Task<List<UserInfoDTO>> GetUsersInfo();
        Task<UserInfoDTO> GetUserInfoById(decimal id);
        Task CreateUserInfo(CreateUserInfoDTO userInfo);
        Task UpdateUserInfo(UpdateUserInfoDTO userInfo);
        Task DeleteUserInfo(decimal id);
        Task<List<StudentDTO>> GetStudents();
    }
}
