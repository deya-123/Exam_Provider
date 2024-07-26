using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProvider.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyInfoController : ControllerBase
    {
        private readonly ICompanyInfoService _companyInfoservise;

        public CompanyInfoController(ICompanyInfoService companyInfoservise)
        {
            _companyInfoservise = companyInfoservise;
        }
        [HttpPost]
        public async Task CreateCompanyInfo(CreateCompanyInfoDTO companyInfo)
        {
            await _companyInfoservise.CreateCompanyInfo(companyInfo);
        }
        [HttpPut]
        public async Task UpdateCompanyInfo(UpdateCompanyInfoDTO companyInfo)
        {
            await _companyInfoservise.UpdateCompanyInfo(companyInfo);
        }
        [HttpDelete("{id}")]
        public async Task DeleteCompanyInfo(decimal id)
        {
            await _companyInfoservise.DeleteCompanyInfo(id);
        }
        [HttpGet]
        public async Task<List<CompanyInfoDTO>> GetCompaniesInfo()
        {
            return await _companyInfoservise.GetCompaniesInfo();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<CompanyInfoDTO> GetCompanyInfoById(decimal id)
        {
            return await _companyInfoservise.GetCompanyInfoById(id);
        }
    }
}
