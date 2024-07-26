using ExamProvider.core.Data;
using ExamProvider.core.DTO;
using ExamProvider.core.IRepositary;
using ExamProvider.core.IService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProvider.infra.Service
{
    public class CompanyInfoService : ICompanyInfoService
    {
        private readonly ICompanyInfoRepository _companyInfoRepository;

        public CompanyInfoService(ICompanyInfoRepository companyInfoRepository)
        {
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task CreateCompanyInfo(CreateCompanyInfoDTO companyInfo)
        {
           await _companyInfoRepository.CreateCompanyInfo(companyInfo);
        }

        public async Task DeleteCompanyInfo(decimal id)
        {
            await _companyInfoRepository.DeleteCompanyInfo(id);
        }

        public async Task<List<CompanyInfoDTO>> GetCompaniesInfo()
        {
          return  await _companyInfoRepository.GetCompaniesInfo();
        }

        public async Task<CompanyInfoDTO> GetCompanyInfoById(decimal id)
        {
          return  await _companyInfoRepository.GetCompanyInfoById(id);
        }

        public async  Task UpdateCompanyInfo(UpdateCompanyInfoDTO companyInfo)
        {
            await _companyInfoRepository.UpdateCompanyInfo(companyInfo);
        }
    }
}
