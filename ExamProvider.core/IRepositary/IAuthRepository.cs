using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.core.IRepositary
{
    public interface IAuthRepository
    {

        public Task<UserInfo> Login(LoginDTO loginDTO);
        public Task<int> Register(RegisterDTO registerDTO);
    }
}
