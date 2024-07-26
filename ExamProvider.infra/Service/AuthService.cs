using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using ExamProvider.infra.Repositary;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IApiInfoRepository _apiInfoRepository;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        public AuthService(IAuthRepository authRepository,
            IApiInfoRepository apiInfoRepository,
            ICompanyInfoRepository companyInfoRepository)
        {
            _authRepository = authRepository;
            _apiInfoRepository = apiInfoRepository;
            _companyInfoRepository = companyInfoRepository;
        }
        public async Task<ApiResponse<UserInfo>> Login(LoginDTO loginDTO)
        {
            var newUser= await _authRepository.Login(loginDTO);
            if (newUser is null) {
                return new ApiResponse<UserInfo>("email or password is not correct");
            }
            return new ApiResponse<UserInfo>(newUser);

        }
        public async Task<string> GenerateExamGuardianToken(LoginDTO loginDTO)
        {
            var user = await _authRepository.Login(loginDTO);
            if (user is null)
            {
                throw new InvalidOperationException("email or password is not correct");
            }
            var apiKey= (await _apiInfoRepository.GetAllApisInfo())
                .FirstOrDefault(e=>e.ServiceName!=null 
                && e.ServiceName.ToLower() == "exam guardian".ToLower());

            if (apiKey is null)
            {
                throw new InvalidOperationException("API key for 'Exam Guardian' not found.");
            }
            if (apiKey.UniqueKey is null) {
                throw new InvalidOperationException("API key for 'Exam Guardian' not found.");
            }

            var uniqueId = apiKey.UniqueKey;

                

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(uniqueId));
                var signCred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

               var companyInfo= await _companyInfoRepository.GetCompanyInfoById(6);
                var claims = new List<Claim>
                {

                     new Claim("company",companyInfo.OrganizationName ?? "microsoft"),
                     new Claim("userId",user.UserId.ToString())
                };

                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(10),
                    signingCredentials: signCred
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return token;          
        }
        public async Task<ApiResponse<string>> Register(RegisterDTO registerDTO)
        {
            var effect = await _authRepository.Register(registerDTO);
            if (effect is 0)
            {
                return new ApiResponse<string>(message:"the process is not success try again");
            }
            return new ApiResponse<string>(data:"");
        }
    }
}
