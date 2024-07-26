using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiInfoController : ControllerBase
    {
        private readonly IApiInfoService _apiInfoService;

        public ApiInfoController(IApiInfoService iapiserviceservise)
        {
            _apiInfoService = iapiserviceservise;
        }
        [HttpPost]
        public async Task CreateApiInfo(CreateApiServiceDTO createApiServiceDTO)
        {
            await _apiInfoService.CreateApiInfo(createApiServiceDTO);
        }
        [HttpGet]
        public async Task<List<ApiServiceDTO>> GetAllApisInfo()
        {
            return await _apiInfoService.GetAllApisInfo();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ApiServiceDTO> GetApiInfoById(decimal id)
        {
            return await _apiInfoService.GetApiInfoById(id);
        }
        [HttpPut]
        public async Task UpdateApiInfo(UpdateApiServiceDTO updateApiServiceDTO)
        {
            await _apiInfoService.UpdateApiInfo(updateApiServiceDTO);

        }
        [HttpDelete("{id}")]
        public async Task DeleteApiInfo(decimal id)
        {
            await _apiInfoService.DeleteApiInfo(id);
        }

    }
}
