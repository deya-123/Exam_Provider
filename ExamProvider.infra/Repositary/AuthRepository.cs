using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.ICommon;
using ExamProvider.core.IRepositary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Repositary
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;
        public AuthRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
        }

        public  async Task<UserInfo> Login(LoginDTO loginDTO)
        {
           return await _modelContext.UserInfos.Where(e => e.UserEmail == loginDTO.UserEmail && e.UserPassword == loginDTO.UserPassword).FirstOrDefaultAsync();
        }

        public async Task<int> Register(RegisterDTO registerDTO)
        {
            var newUser=new UserInfo() { 
            
                UserEmail=registerDTO.UserEmail,
                UserPassword=registerDTO.UserPassword,
                UserName=registerDTO.UserName,
            
            };

            _modelContext.Add(newUser);

           return await _modelContext.SaveChangesAsync();

        }
    }
}
