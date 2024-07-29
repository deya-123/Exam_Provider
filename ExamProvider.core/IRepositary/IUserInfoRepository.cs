using ExamProvider.core.Data;

using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IRepositary
{
    public interface IUserInfoRepository
    {
        Task<List<UserInfoDTO>> GetUsersInfo();
        Task<UserInfoDTO> GetUserInfoById(decimal id);
        Task CreateUserInfo(CreateUserInfoDTO userInfo);
        Task UpdateUserInfo(UpdateUserInfoDTO userInfo);
        Task DeleteUserInfo(decimal id);
        Task<List<StudentDTO>> GetStudents();
        Task<StudentDTO> GetStudentInfoByEmail(string email);
        Task<StudentDTO> GetStudentInfoById(decimal id);
    }

}
