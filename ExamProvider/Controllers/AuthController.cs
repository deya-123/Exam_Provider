
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using ExamProvider.infra.Service;
using ExamProvider.core.Data;

namespace ExamProviderMVC.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Keys.Where(key => ModelState[key].Errors.Any())
                    .ToDictionary(key => key, key => ModelState[key].Errors.Select(x => x.ErrorMessage).ToList());
                var response = new ApiResponse<LoginDTO>(message: "Validation failed", validationErrors: validationErrors);
                return BadRequest(response);
            }

            return Ok(await _authService.Login(loginDTO));

        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {

            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Keys.Where(key => ModelState[key].Errors.Any())
                    .ToDictionary(key => key, key => ModelState[key].Errors.Select(x => x.ErrorMessage).ToList());
                var response = new ApiResponse<string>(message: "Validation failed", validationErrors: validationErrors);
                return BadRequest(response);
            }

            return Ok(await _authService.Register(registerDTO));

        }



        [HttpPost]
        public async Task<IActionResult> GenerateExamGuardianToken(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Keys.Where(key => ModelState[key].Errors.Any())
                    .ToDictionary(key => key, key => ModelState[key].Errors.Select(x => x.ErrorMessage).ToList());
                var response = new ApiResponse<LoginDTO>(message: "Validation failed", validationErrors: validationErrors);
                return BadRequest(response);
            }

            return Ok(await _authService.GenerateExamGuardianToken(loginDTO));

        }







    }
}
