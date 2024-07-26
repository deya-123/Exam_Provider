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
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task CreateUserInfo(CreateUserInfoDTO userInfo)
        {
           await _userInfoRepository.CreateUserInfo(userInfo);
        }

        public async Task DeleteUserInfo(decimal id)
        {
            await _userInfoRepository.DeleteUserInfo(id);
        }

        public async Task<List<StudentDTO>> GetStudents()
        {
           return await _userInfoRepository.GetStudents();
        }

        public async Task<UserInfoDTO> GetUserInfoById(decimal id)
        {
           return await _userInfoRepository.GetUserInfoById(id);
        }

        public async Task<List<UserInfoDTO>> GetUsersInfo()
        {
            return await _userInfoRepository.GetUsersInfo();
        }

        public async Task UpdateUserInfo(UpdateUserInfoDTO userInfo)
        {
            await _userInfoRepository.UpdateUserInfo(userInfo);
        }
    }
}