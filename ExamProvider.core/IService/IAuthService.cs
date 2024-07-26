using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IService
{
    public interface IAuthService
    {

        public Task<ApiResponse<UserInfo>> Login(LoginDTO loginDTO);
        public Task<ApiResponse<string>> Register(RegisterDTO registerDTO);
        public Task<string> GenerateExamGuardianToken(LoginDTO loginDTO);
    }
}
